using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class ScrollViewAdd : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    [SerializeField]
    private GameObject elementPrefab = null;

    [SerializeField]
    private Transform content = null;

    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
    }


    public void OnClicked()
    {
        PV.RPC("AddElement", RpcTarget.OthersBuffered);
        AddElement();
    }

    [PunRPC]
    public void AddElement()
    {
        var instance = Instantiate(elementPrefab);
        instance.transform.SetParent(content, false);
    }
}
