using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class AttackRange : Node
{
    private Transform _transform;
    private float _attackRange;
    private float _attackCooldown = 1f;
    private float _attackTime = 0.1f; 
    public AttackRange(Transform transform, float attackRange)
    {
        _transform = transform;
        _attackRange = attackRange; 
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target"); 
        if(t == null)
        {
            state = NodeState.Failure;
            return state;
        }
        Transform target = (Transform)t;
        if (target.CompareTag("Player") || target.CompareTag("Sheep"))
        {
            if (target.CompareTag("Player") && Vector3.Distance(_transform.position, target.position) <= _attackRange)
            {
                _attackCooldown -= Time.deltaTime;
                if (_attackCooldown <= _attackTime)
                {
                    target.GetComponent<Character>().TakeDamage(1);
                    _attackCooldown = 1;
                }
                ClearData("target");
                state = NodeState.Success;
                return state;
            }
            if (target.CompareTag("Sheep") && Vector3.Distance(_transform.position, target.position) <= _attackRange)
            {
                SheepBT.sheephealth -= 1;
                ClearData("target");
                state = NodeState.Success;
                return state;
            }
            state = NodeState.Failure;
            return state;
        }
        state = NodeState.Failure;
        return state;
    }
    
}