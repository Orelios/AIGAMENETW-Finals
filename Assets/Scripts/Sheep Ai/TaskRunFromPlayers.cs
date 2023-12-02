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
    private LayerMask _traps; 
    public TaskRunFromPlayers(Transform transform, NavMeshAgent agent, float runDistance, LayerMask traps)
    {
        _transform = transform;
        _agent = agent;
        _runDistance = runDistance;
        _traps = traps; 
    }
    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target.CompareTag("Wolf"))
        {
            RunFromPlayer();
            ClearData("target");
            state = NodeState.Success;
            return state;
        }
        else if (target.CompareTag("Player"))
        {
            RunFromPlayer();
            ClearData("target");
            state = NodeState.Success;
            return state; 
        }
        ClearData("target");
        state = NodeState.Failure;
        return state;
    }

    private void RunFromPlayer()
    {
        Transform target = (Transform)GetData("target");
        if (Vector3.Distance(_transform.position, target.position) < _runDistance)
        {
            Vector3 distanceFromPlayer = _transform.position - target.position;
            Vector3 newDirection = _transform.position + distanceFromPlayer;

            RaycastHit hit;
            if (Physics.SphereCast(_transform.position, 1, _transform.forward, out hit, 2, _traps))
            {
                Debug.Log("detects layer vro");
                _agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
                _agent.speed = _speed;
                //hit.collider.gameObject.transform.position
            }
            _agent.speed = _speed;
            _agent.SetDestination(newDirection);
        }
        else
        {
            _agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        }
       
    }
}
