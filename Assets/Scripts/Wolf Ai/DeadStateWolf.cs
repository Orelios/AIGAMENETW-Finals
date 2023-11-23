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
        if (_wolf.GetComponent<Character>().currHealth == 0)
        {
            _wolf.GetComponent<Character>().currHealth += _wolf.GetComponent<Character>().maxHealth;
            _wolf.GetComponentInChildren<Canvas>().enabled = false;
            ObjectPoolManager.ReturnObjectToPool(_wolf);
            state = NodeState.Success;
            return state;
        }

        state = NodeState.Failure;
        return state;
    }

}

