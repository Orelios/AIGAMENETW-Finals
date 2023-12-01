using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using Photon.Pun;
using System;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class DeathStateWolf : Node
{
    private GameObject _wolf;
    public DeathStateWolf(GameObject wolf)
    {
        _wolf = wolf;
    }
    public override NodeState Evaluate()
    {
        if (_wolf.GetComponent<Character>().currHealth == 0)
        {
            _wolf.GetComponent<Character>().currHealth += _wolf.GetComponent<Character>().maxHealth;
            _wolf.GetComponentInChildren<Canvas>().enabled = false;
            NetworkDestroy();
            //ObjectPoolManager.ReturnObjectToPool(_wolf);
            state = NodeState.Success;
            return state;
        }

        state = NodeState.Failure;
        return state;
    }

    public void NetworkDestroy()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            DestroyGlobally();
        }

        //else
            //DestroyLocally();
    }

    private void DestroyLocally()
    {
        //isDestroyed = true;
    }

    private void DestroyGlobally()
    {
        PhotonNetwork.Destroy(_wolf);
        //isDestroyed = true;
    }
}

