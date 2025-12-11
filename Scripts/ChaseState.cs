using UnityEngine;

public class ChaseState : AIState
{
    private NPCInputHandler npcInput;

    public ChaseState(Enemy enemy) : base(enemy)
    {
        stateType = AIStateType.Chase;
    }

    public override void Enter()
    {
        Debug.Log($"{enemy.gameObject.name} entered Chase state");
        npcInput = enemy.GetInputHandler() as NPCInputHandler;
    }

    public override void Update()
    {
        float distanceToTarget = enemy.GetDistanceToTarget();

        if (distanceToTarget <= enemy.Data.AttackRange)
        {
            enemy.ChangeState(AIStateType.Attack);
        }
        else if (distanceToTarget > enemy.Data.DetectionRange)
        {
            enemy.ChangeState(AIStateType.Idle);
        }
    }

    public override void Exit()
    {
        
    }
}

