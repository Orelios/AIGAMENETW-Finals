using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree; 

public class DeathState : Node
{
    private GameObject _sheep;

    public DeathState(GameObject sheep)
    {
        _sheep = sheep; 
    }
    public override NodeState Evaluate()
    {
        if (SheepBT.sheephealth == 0)
        {
            _sheep.SetActive(false);
            state = NodeState.Success;
            return state;
        }
        state = NodeState.Failure;
        return state;
    }

}
