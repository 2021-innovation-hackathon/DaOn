using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class ScrollViewAdd : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    static int cnt = 0;
    [SerializeField]
    private GameObject[] elementPrefab = new GameObject[5];

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
        var instance = Instantiate(elementPrefab[cnt]);
        instance.transform.SetParent(content, false);
        cnt++;
    }
}
