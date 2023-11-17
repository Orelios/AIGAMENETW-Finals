using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using BehaviorTree; 
public class TaskChase : Node
{
    private Transform _transform;
    private LayerMask _playerLayer;
    private NavMeshAgent _agent; 

    public TaskChase(Transform transform, NavMeshAgent agent)
    {
        _transform = transform;
        _agent = agent; 
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target.CompareTag("Sheep"))
        {
            RunTowards();
            WolfFOV();
            state = NodeState.Success;
            return state;
        }
        else if (target.CompareTag("Player"))
        {
            RunTowards();
            WolfFOV(); 
            state = NodeState.Success;
            return state;
        }
        state = NodeState.Failure;
        return state;
    }
    private void RunTowards()
    {
        Transform target = (Transform)GetData("target");
        _agent.SetDestination(target.position);
    }
    private void WolfFOV()
    {
        Transform target = (Transform)GetData("target");
        if (Vector3.Distance(_transform.position, target.position) > 10)
        {
            ClearData("target");
        }
    }
}
