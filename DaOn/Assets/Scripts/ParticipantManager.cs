using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class ParticipantManager : MonoBehaviour
{
    public Text chatters;
    public ScrollRect scroll_rect;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        chatterUpdate();
    }

    void chatterUpdate()
    {
        chatters.text = "Player List\n";
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            chatters.text += p.NickName + "\n";
        }
        scroll_rect.verticalNormalizedPosition = 0.0f;
    }
}
