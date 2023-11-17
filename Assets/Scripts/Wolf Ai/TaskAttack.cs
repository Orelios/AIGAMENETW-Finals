using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree; 

public class TaskAttack : Node
{
    private Transform _transform;

    public TaskAttack(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        

        state = NodeState.Failure;
        return state; 
    }
}
