using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree; 
public class CheckPlayerInFOVRange : Node
{
    private Transform _transform;
    private LayerMask _playerLayer;
    private LayerMask _sheepLayer; 
    private float _FOVRange; 
    public CheckPlayerInFOVRange(Transform transform, LayerMask playerLayer, float FOVRange)
    {
        _transform = transform;
        _playerLayer = playerLayer;
        _FOVRange = FOVRange; 
    }
    public override NodeState Evaluate()
    {
        object t = GetData("target"); 
        if(t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position, _FOVRange, _playerLayer); 
            if(colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);
                state = NodeState.Success;
                return state;
            }
            state = NodeState.Failure;
            return state;
        }
        state = NodeState.Success;
        return state;
    }
}
