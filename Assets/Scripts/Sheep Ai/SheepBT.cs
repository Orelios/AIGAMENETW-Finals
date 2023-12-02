using System.Collections.Generic;
using UnityEngine.AI; 
using BehaviorTree;

public class SheepBT : BehaviorTree.BehaviorTree
{
    [UnityEngine.Header("TaskRoam Variables")]
    // roaming
    public UnityEngine.LayerMask groundLayer; 
    public UnityEngine.LayerMask playerLayer;
    public UnityEngine.LayerMask traps;
    public NavMeshAgent agent;
    public float speed = 2.0f;
    public UnityEngine.Transform[] waypoints;
    public float roamToWaypointDistance = 10;

    [UnityEngine.Header("CheckPlayerFOVRange Variables")]
    //CheckPlayerFOVRange variables
    public float FOVRange = 5f;

    [UnityEngine.Header("TaskRunAwayFromPlayers Variables")]
    //TaskRunAwayFromPlayers
    public float runDistance = 5;
    [UnityEngine.Header("DeathState Variables")]
    //DeathState variables
    public UnityEngine.GameObject sheep;
    //public UnityEngine.GameObject enemy;
    public static int sheephealth = 1;
    public bool isInsideFence = false; 
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.GetComponent<Character>().currHealth -= 1; 
            //sheephealth -= 1;
        }
    }
    private void OnDrawGizmos()
    {
        UnityEngine.Gizmos.color = UnityEngine.Color.blue;
        UnityEngine.Gizmos.DrawSphere(transform.position + transform.forward * 2, 1);
    }
    protected override Node SetupTree()
    {
        //Node root = new TaskRoam(transform, waypoints, speed);

        //return root; 

        Node root = new Selector(new List<Node>
        {
            new DeathState(sheep),
            new Sequence(new List<Node>
            {
                new CheckPlayerInFOVRange(transform, playerLayer, FOVRange),
                new TaskRunFromPlayers(transform, agent, runDistance, traps),
            }),
            new TaskRoam(groundLayer, playerLayer, transform, waypoints, agent, speed, roamToWaypointDistance),
        });
                                                 
        return root; 
    }
}
