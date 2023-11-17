using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class DeathStateWolf : Node
{
    private GameObject _wolf;

    public DeathStateWolf(GameObject wolf)
    {
        _wolf = wolf;
    }
    public override NodeState Evaluate()
    {
        if (WolfBT.wolfHealth == 0)
        {
            _wolf.SetActive(false);
            state = NodeState.Success;
            return state;
        }
        state = NodeState.Failure;
        return state;
    }

}

