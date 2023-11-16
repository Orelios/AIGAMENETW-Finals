using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using BehaviorTree; 

public class TaskRoam : Node
{
    private NavMeshAgent _agent;
    private LayerMask _groundLayer, _playerLayer;

    //roam variables
    private bool walkPointSet;
    private Transform _transform;
    private Transform[] _waypoints;
    private int _currentWaypointIndex = 0;
    private Transform wp;
    private float _speed;
    private float _roamToWaypointDistance; 

    //waiting variables
    private float _waitTime = 3f;
    private float _waitCounter = 0f;
    private bool _waiting = false;
    public TaskRoam (LayerMask groundlayer, LayerMask playerLayer, Transform transform, 
        Transform[] waypoints, NavMeshAgent agent, float speed, float roamToWaypointDistance)
    {
        _groundLayer = groundlayer;
        _playerLayer = playerLayer;
        _transform = transform;
        _agent = agent;
        _waypoints = waypoints;
        _speed = speed;
        _roamToWaypointDistance = roamToWaypointDistance; 
    }
    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waiting = false;
            }

        }
        else
        {
            if (!walkPointSet)
            {
                wp = _waypoints[_currentWaypointIndex];
                walkPointSet = true;
            }
            if (Vector3.Distance(_transform.position, wp.position) < 1f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                walkPointSet = false;
                _waitCounter = 0f;
                _waiting = true;
            }
            if (Vector3.Distance(_transform.position, wp.position) <= _roamToWaypointDistance)
            {
                if (walkPointSet)
                {
                    _agent.speed = _speed;
                    _agent.SetDestination(wp.position);
                    state = NodeState.Success;
                    return state;
                }
                else
                {
                    state = NodeState.Failure;
                    return state;
                }
            }
        }
        state = NodeState.Failure;
        return state;
    }
}
