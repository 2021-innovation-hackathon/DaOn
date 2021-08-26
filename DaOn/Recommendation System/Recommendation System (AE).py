import pandas as pd
import torch
import torch.nn as nn
import torch.nn.functional as F
import numpy as np
import torch.optim as optim
from sklearn.utils import shuffle
from torch.autograd import Variable

#Data Processing

action = np.random.binomial(n=1, p=0.508, size=10000)
action_ep=np.expand_dims(action, 1)
drama = np.random.binomial(n=1, p=0.458, size=10000)
drama_ep=np.expand_dims(drama, 1)
thriler = np.random.binomial(n=1, p=0.339, size=10000)
thriler_ep=np.expand_dims(thriler, 1)
romenticcomedy = np.random.binomial(n=1, p=0.297, size=10000)
romenticcomedy_ep=np.expand_dims(romenticcomedy, 1)
sf = np.random.binomial(n=1, p=0.228, size=10000)
sf_ep=np.expand_dims(sf, 1)
fantasy= np.random.binomial(n=1, p=0.220, size=10000)
fantasy_ep=np.expand_dims(fantasy, 1)
comedy = np.random.binomial(n=1, p=0.196, size=10000)
comedy_ep=np.expand_dims(comedy, 1)
noir = np.random.binomial(n=1, p=0.172, size=10000)
noir_ep=np.expand_dims(noir, 1)
mystery = np.random.binomial(n=1, p=0.132, size=10000)
mystery_ep=np.expand_dims(mystery, 1)
documentary = np.random.binomial(n=1, p=0.072, size=10000)
documentary_ep=np.expand_dims(documentary, 1)
fear = np.random.binomial(n=1, p=0.072, size=10000)
fear_ep=np.expand_dims(fear, 1)
melo = np.random.binomial(n=1, p=0.072, size=10000)
melo_ep=np.expand_dims(melo, 1)
musical = np.random.binomial(n=1, p=0.056, size=10000)
musical_ep=np.expand_dims(musical, 1)

total = np.concatenate((action_ep, drama_ep, thriler_ep, romenticcomedy_ep, sf_ep, fantasy_ep, comedy_ep,
                     noir_ep, mystery_ep, documentary_ep, fear_ep, melo_ep, musical_ep), axis=1)

total_ep=np.expand_dims(total, 1)

total_train = total_ep[:8000]

total_test = total_ep[8000:]

total_train = torch.FloatTensor(total_train)

total_test = torch.FloatTensor(total_test)

# model

class Autorec(nn.Module):
    def __init__(self, hidden_size_1, hidden_size_2, hidden_size_3, hidden_size_4, dropout, input_size):
        super(Autorec, self).__init__()
        self.input_size = input_size
        self.hidden_size_1 = hidden_size_1
        self.hidden_size_2 = hidden_size_2
        self.hidden_size_3 = hidden_size_3
        self.hidden_size_4 = hidden_size_4

        self.encoder_l1 = nn.Linear(self.input_size, self.hidden_size_1)
        self.encoder_l2 = nn.Linear(self.hidden_size_1, self.hidden_size_2)
        self.encoder_l3 = nn.Linear(self.hidden_size_2, self.hidden_size_3)
        self.encoder_l4 = nn.Linear(self.hidden_size_3, self.hidden_size_4)

        self.decoder_l1 = nn.Linear(self.hidden_size_4, self.hidden_size_3)
        self.decoder_l2 = nn.Linear(self.hidden_size_3, self.hidden_size_2)
        self.decoder_l3 = nn.Linear(self.hidden_size_2, self.hidden_size_1)
        self.decoder_l4 = nn.Linear(self.hidden_size_1, self.input_size)

        self.drop = nn.Dropout(dropout)
        # self.sigmoid=nn.LogSigmoid()

    def forward(self, input_ratings):
        # input_ratings=F.normalize(input_ratings)
        enc_out = self.encoder_l4(F.relu(self.encoder_l3(F.relu(self.encoder_l2(F.relu(self.encoder_l1(input_ratings)))))))
        enc_out = self.drop(enc_out)
        dec_out = self.decoder_l4(F.relu(self.decoder_l3(F.relu(self.decoder_l2(F.relu(self.decoder_l1(enc_out)))))))
        return enc_out,dec_out

# hyperparmeter

def adjust_learning_rate(optimizer, epoch, lr):
    """Sets the learning rate to the initial LR decayed by 10 every 30 epochs"""
    lr = lr * (0.1 ** (epoch // 20))
    for param_group in optimizer.param_groups:
        param_group['lr'] = lr

    return lr

def mean_squared_error(y, t):
    return 0.5 * torch.sum((y-t)**2)

autorec=Autorec(hidden_size_1=256, hidden_size_2=128, hidden_size_3=64, hidden_size_4=32, dropout=0.1, input_size=total_ep.shape[2])
optimizer=optim.Adam(autorec.parameters(), lr=0.0001)
device=torch.device('cuda')
criterion=nn.MSELoss()
autorec=autorec.to(device)



# train

def train(dataloader, model, criterion, optimizer, epoch, lr):
    # switch to train mode
    model.train()

    loss_total = 0

    for i, (data) in enumerate(dataloader):

        data = data.cuda()

        # compute output
        latent_vector ,output = model(data)

        loss = criterion(output, data)

        # compute gradient and do SGD step
        optimizer.zero_grad()
        loss.backward()
        optimizer.step()

        loss_total += loss

    loss = loss_total/len(dataloader)

    print("Epoch : ",epoch)
    print("LearningRate : ",lr)
    print("Loss : ",loss)
    print("input : ",data)
    print("latent vector : ",latent_vector)
    print("ouput : ",output)


# validation

def validate(val_loader, model):
    model.eval()

    with torch.no_grad():
        for i, (data) in enumerate(val_loader):
            data = data.cuda()

            # compute output
            latent_vector ,output = model(data)
            MSE = mean_squared_error(output, data)

        print("validation_MSE : ",MSE)

    return MSE



start_epoch = 0
epochs = 1000
lr = 0.0001
MSE = 1

for epoch in range(start_epoch, epochs):

    lr = adjust_learning_rate(optimizer, epoch , lr)

    train(total_train, autorec, criterion, optimizer, epoch ,lr)

    result  = validate(total_test, autorec)

    PATH = './'

    if MSE > result:

        torch.save(autorec, PATH + 'model_1.pt')  # 전체 모델 저장
        torch.save(autorec.state_dict(), PATH + 'model_state_dict_1.pt')  # 모델 객체의 state_dict 저장
        torch.save({
            'model': autorec.state_dict(),
            'optimizer': optimizer.state_dict()
        }, PATH + 'all.tar')

        MSE = result


