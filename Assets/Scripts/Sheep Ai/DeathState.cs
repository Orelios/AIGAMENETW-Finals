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
                Score.Instance.SubtractScore(Score.Instance.sheepLostSubtraction);
                ObjectiveCounter.Instance.SubtractSheepHerded();
                _sheep.gameObject.GetComponent<SheepBT>().isInsideFence = false;
            }
            else if(_sheep.gameObject.GetComponent<SheepBT>().isInsideFence == false) //sheep dies while outside fence
            {
                ObjectiveCounter.Instance.SubtractSheepLeft();
            }
            _sheep.GetComponent<SheepBT>().SheepDie();
            _sheep.SetActive(false);
            state = NodeState.Success;
            return state;
        }
        state = NodeState.Failure;
        return state;
    }

}
