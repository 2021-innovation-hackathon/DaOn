using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Exit : MonoBehaviourPunCallbacks
{

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Main");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

}
