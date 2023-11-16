using System.Collections.Generic;
using UnityEngine.AI; 
using BehaviorTree;

public class SheepBT : Tree
{
    [UnityEngine.Header("TaskRoam Variables")]
    //test random roaming
    public UnityEngine.LayerMask groundLayer; 
    public UnityEngine.LayerMask playerLayer;
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
    protected override Node SetupTree()
    {
        //Node root = new TaskRoam(transform, waypoints, speed);

        //return root; 

        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckPlayerInFOVRange(transform, playerLayer, FOVRange),
                new TaskRunFromPlayers(transform, agent, runDistance),
            }),
            new TaskRoam(groundLayer, playerLayer, transform, waypoints, agent, speed, roamToWaypointDistance),
        });
                                                 
        return root; 
    }
   
}
