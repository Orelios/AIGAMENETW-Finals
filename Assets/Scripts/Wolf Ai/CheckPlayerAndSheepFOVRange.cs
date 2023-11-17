using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckPlayerAndSheepFOVRange : Node
{
    private Transform _transform;
    private LayerMask _playerLayer;
    private LayerMask _sheepLayer; 
    private float _FOVRange;

    public CheckPlayerAndSheepFOVRange(Transform transform, LayerMask playerLayer, LayerMask sheepLayer, float FOVRange)
    {
        _transform = transform;
        _playerLayer = playerLayer;
        _sheepLayer = sheepLayer;
        _FOVRange = FOVRange; 
    }

    public override NodeState Evaluate()
    {
        return base.Evaluate();
    }
}
