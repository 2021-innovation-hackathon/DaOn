using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class UserData : MonoBehaviourPunCallbacks
{
    int roomCnt;
    string userName;
    int[] firstPerson = { 2, 0, 3, 1 };
    Dictionary<string, int> userID = new Dictionary<string, int>();


    float[,] userData = { { 1.000f, 0.425f, -0.069f, -0.025f },
        {0.425f,1.000f,0.575f, -0.160f },
        {-0.069f, 0.575f, 1.000f, 0.8655f },
        {-0.025f, -0.160f, 0.8655f, 1.000f } };


     void Start()
    {
        //PhotonNetwork.ConnectUsingSettings();
        userName = PhotonNetwork.LocalPlayer.NickName;
        print(PhotonNetwork.LocalPlayer.NickName);

        userID.Add("Ryeeun", 0);
        userID.Add("Chan", 1);
        userID.Add("Jenny", 2);
        userID.Add("NoJam", 3);
        //userName = "Ryeeun";
    }


        // nickname 
        // 첫 번째 입장자는 바로 룸만들기
        // 두 번째 입장자는 첫 번째랑 비교 후 0.8보다 작으면 방 생성, 크면 같은 방
        // 방이 2개 이상일 때, 방들 모두 비교 중 0.8보다 크면 그 방으로, 모두 작으면 새로운 방 생성

     public void matchAndEnter()
    {
        if (roomCnt == 0)
        {
            // 포톤에서 자신의 nickname 받아서 저장
            print(userName);
            firstPerson[0] = userID[userName];
            // 바로 방 생성 후 입장
            PhotonNetwork.CreateRoom("Music1", new RoomOptions { MaxPlayers = 4 });
            PhotonNetwork.JoinRoom("Music1");
            
        }
        else if (roomCnt == 1)
        {
            print("firstPerson[0]" + firstPerson[0] + "\n" + "userID[userName]" + userID[userName]);
            if (userData[firstPerson[0], userID[userName]] < 0.8)
            {
                firstPerson[1] = userID[userName];
                PhotonNetwork.CreateRoom("Music2", new RoomOptions { MaxPlayers = 4 });
                PhotonNetwork.JoinRoom("Music2");
            }
            else
            {
                PhotonNetwork.JoinRoom("Music1");
            }
        }
        else
        {
            for (int i = 0; i < roomCnt; i++)
            {
                if (userData[firstPerson[i], userID[userName]] < 0.8)
                {
                    continue;
                }
                else
                {
                    int n = i + 1;
                    PhotonNetwork.JoinRoom("Music" + n.ToString());
                    return;
                }
            }
            int nextRoom = roomCnt + 1;
            PhotonNetwork.CreateRoom("Music" + nextRoom.ToString(), new RoomOptions { MaxPlayers = 4 });
            PhotonNetwork.JoinRoom("Music" + nextRoom.ToString());
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)//포톤의 룸 리스트 기능
    {
        roomCnt = roomList.Count;
        print("방개수: " + roomCnt);
    }

    public override void OnCreatedRoom() => print("방만들기 완료");

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Music");
    }

    public override void OnCreateRoomFailed(short returCode, string message) { }

    public override void OnJoinRoomFailed(short returCode, string message) { }




}
