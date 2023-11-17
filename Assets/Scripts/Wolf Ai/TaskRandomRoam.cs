using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI; 

public class TaskRandomRoam : Node
{
    private NavMeshAgent _agent;
    private Transform _transform; 

    private LayerMask _player;
    private LayerMask _sheep;
    private LayerMask _groundLayer; 

    private Vector3 destinationPoint;
    private bool walkPointSet = false;
    private float _range; 

    public TaskRandomRoam(NavMeshAgent agent, Transform transform, 
        LayerMask player, LayerMask sheep, float range, LayerMask groundLayer)
    {
        _agent = agent;
        _transform = transform; 
        _player = player;
        _sheep = sheep;
        _range = range;
        _groundLayer = groundLayer; 
    }
    public override NodeState Evaluate()
    {
        if (!walkPointSet)
        {
            //Debug.Log("setup loacation"); 
            SearchNextLocation(); 
        }
        if (walkPointSet)
        {
            _agent.SetDestination(destinationPoint);
        }
        if(Vector3.Distance(_transform.position, destinationPoint) < 1f)
        {
            walkPointSet = false; 
        }
        state = NodeState.Running;
        return state;
    }

    private void SearchNextLocation()
    {
        float z = Random.Range(-_range, _range);
        float x = Random.Range(-_range, _range);

        destinationPoint = new Vector3(_transform.position.x + x, 
            _transform.position.y, _transform.position.z + z);

        if (Physics.Raycast(destinationPoint, Vector3.down, _groundLayer))
        {
            walkPointSet = true; 
        }
    }
}
