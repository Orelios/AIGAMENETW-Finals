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
        if (_sheep.GetComponent<Character>().currHealth == 0)
        {
            if(_sheep.gameObject.GetComponent<SheepBT>().isInsideFence == true) //sheep dies while inside fence
            {
                Score.Instance.score -= Score.Instance.sheepLostSubtraction;
                ObjectiveCounter.Instance.sheepHerded -= 1;
                _sheep.gameObject.GetComponent<SheepBT>().isInsideFence = false;
            }
            else if(_sheep.gameObject.GetComponent<SheepBT>().isInsideFence == false) //sheep dies while outside fence
            {
                ObjectiveCounter.Instance.sheepLeft -= 1;
            }
            _sheep.SetActive(false);
            state = NodeState.Success;
            return state;
        }
        state = NodeState.Failure;
        return state;
    }

}
