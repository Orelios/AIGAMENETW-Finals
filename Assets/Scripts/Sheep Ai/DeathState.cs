using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree; 

public class DeathState : Node
{
    private int _sheepHealth;
    private GameObject _sheep; 

    public DeathState(int sheepHealth, GameObject sheep)
    {
        _sheepHealth = sheepHealth;
        _sheep = sheep; 
    }
    public override NodeState Evaluate()
    {
        if(_sheepHealth <= 0)
        {
            _sheep.SetActive(false); 
            state = NodeState.Success;
            return state;
        }
        state = NodeState.Failure;
        return state;
    }
}
