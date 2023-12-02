using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class SoundStartLevel : MonoBehaviour
{
    private PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
        PlayLevelMusic();
    }

    public void PlayLevelMusic()
    {
        //Ensure that the RPC call will be handled only by the local player
        if (!photonView.IsMine)
        {
            return;
        }
        photonView.RPC("RPCPlayLevelMusic", RpcTarget.AllViaServer);
        Debug.Log("Play Music");
    }

    [PunRPC]
    private void RPCPlayLevelMusic()
    {
        SoundManager.PlayMusic(SoundManager.Music.LevelTheme);
    }
}
