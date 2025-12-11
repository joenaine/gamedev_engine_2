using UnityEngine;

public class IdleState : AIState
{
    public IdleState(Enemy enemy) : base(enemy)
    {
        stateType = AIStateType.Idle;
    }

    public override void Enter()
    {
        Debug.Log($"{enemy.gameObject.name} entered Idle state");
    }

    public override void Update()
    {
        float distanceToTarget = enemy.GetDistanceToTarget();

        if (distanceToTarget <= enemy.Data.DetectionRange && distanceToTarget > enemy.Data.AttackRange)
        {
            enemy.ChangeState(AIStateType.Chase);
        }
        else if (distanceToTarget <= enemy.Data.AttackRange)
        {
            enemy.ChangeState(AIStateType.Attack);
        }
    }

    public override void Exit()
    {
        
    }
}

