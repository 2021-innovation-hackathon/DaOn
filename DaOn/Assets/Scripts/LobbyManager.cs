using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    public Button loginBtn;
    public Text IDText;
    public Text ConnectionStatus;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        loginBtn.interactable = false;
        ConnectionStatus.text = "Connecting...";
    }

    public void Connect()
    {
        if (IDText.text.Equals(""))
        {
            return;
        }
        else
        {
            PhotonNetwork.LocalPlayer.NickName = IDText.text;
            loginBtn.interactable = false;
            if (PhotonNetwork.IsConnected)
            {
                ConnectionStatus.text = "connenting to room...";
                //PhotonNetwork.JoinRandomRoom();
                PhotonNetwork.JoinLobby();
            }
            else
            {
                ConnectionStatus.text = "Offline : failed to connect. \nreconnecting...";
                PhotonNetwork.ConnectUsingSettings();
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        loginBtn.interactable = true;
        ConnectionStatus.text = "Online : connected to master server";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        loginBtn.interactable = false;
        ConnectionStatus.text = "Offline : failed to connect.\nreconnecting...";
        PhotonNetwork.ConnectUsingSettings();
    }

    /*
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        ConnectionStatus.text = "No empty room. creating new room...";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 0 });
        // MaxPlayers = 0 ���� �ϸ� �ο� ���� x
    }
    */
    

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("Main");
        // ��Ʈ��ũ ������ �״�� �������� ���� SceneManager.LoadScene()�� ������� ����
    }
}
