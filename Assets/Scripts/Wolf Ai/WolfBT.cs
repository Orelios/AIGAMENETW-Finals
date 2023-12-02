using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class WolfBT : BehaviorTree.BehaviorTree
{
    public NavMeshAgent agent;
    public LayerMask player;
    public LayerMask sheep;
    public LayerMask groundLayer;
    public float range = 5;
    public float FOVRange = 10;
    public float attackRange;
    public GameObject wolf;
    //public Camera camera; 

    private PhotonView photonView;

    private void Awake()
    {
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
        photonView = GetComponent<PhotonView>();
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SoundManager.PlaySFXOneShot(SoundManager.SFX.WolfHurt);
            gameObject.GetComponentInChildren<Canvas>().enabled = true;
            gameObject.GetComponent<Character>().currHealth -= 1; 
        }
    }
    public void WolfDie()
    {
        SoundManager.PlaySFXOneShot(SoundManager.SFX.WolfDeath);
        //Ensure that the RPC call will be handled only by the local player
        if (!photonView.IsMine)
        {
            return;
        }
        photonView.RPC("RPCWolfDie", RpcTarget.AllViaServer);
        Debug.Log("Wolf Death");
    }

    [PunRPC]

    private void RPCWolfDie()
    {
        this.gameObject.SetActive(false);
    }

    protected override Node SetupTree()
    {
        //Node root = new TaskRandomRoam(agent, transform, player, sheep, range, groundLayer);
        
        //return root; 

        Node root = new Selector(new List<Node>
        {
            new DeathStateWolf(wolf),
            new AttackRange(transform, attackRange),
            new Sequence(new List<Node>
            {
                new CheckPlayerInFOVRange(transform, player, FOVRange),
                new TaskChase(transform, agent),
            }),
            new TaskRandomRoam(agent, transform, player, sheep, range, groundLayer),
        });
        return root;
    }
}
