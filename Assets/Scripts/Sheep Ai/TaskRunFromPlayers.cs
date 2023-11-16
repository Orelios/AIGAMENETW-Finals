using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI; 
public class TaskRunFromPlayers : Node
{
    private Transform _transform;
    private NavMeshAgent _agent;
    private float _speed = 2f;
    private float _runDistance; 
    public TaskRunFromPlayers(Transform transform, NavMeshAgent agent, float runDistance)
    {
        _transform = transform;
        _agent = agent;
        _runDistance = runDistance; 
    }
    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target"); 
        if(Vector3.Distance(_transform.position, target.position) < _runDistance)
        {
            Vector3 distanceFromPlayer = _transform.position - target.position;
            Vector3 newDirection = _transform.position + distanceFromPlayer;

            _agent.speed = _speed;
            _agent.SetDestination(newDirection);
            ClearData("target");
            state = NodeState.Running;
            return state;
        }
        state = NodeState.Failure;
        return state;
    }
}
