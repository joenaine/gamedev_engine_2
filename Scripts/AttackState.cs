using UnityEngine;

public class AttackState : AIState
{
    private float attackCooldown;
    private float lastAttackTime;
    private NPCInputHandler npcInput;

    public AttackState(Enemy enemy) : base(enemy)
    {
        stateType = AIStateType.Attack;
        attackCooldown = 1.5f;
        lastAttackTime = -attackCooldown;
    }

    public override void Enter()
    {
        Debug.Log($"{enemy.gameObject.name} entered Attack state");
        npcInput = enemy.GetInputHandler() as NPCInputHandler;
    }

    public override void Update()
    {
        float distanceToTarget = enemy.GetDistanceToTarget();

        if (distanceToTarget > enemy.Data.AttackRange)
        {
            npcInput?.SetAttackCommand(false);
            
            if (distanceToTarget <= enemy.Data.DetectionRange)
            {
                enemy.ChangeState(AIStateType.Chase);
            }
            else
            {
                enemy.ChangeState(AIStateType.Idle);
            }
            return;
        }

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            npcInput?.SetAttackCommand(true);
            enemy.PerformAttack();
            lastAttackTime = Time.time;
        }
        else
        {
            npcInput?.SetAttackCommand(false);
        }
    }

    public override void Exit()
    {
        npcInput?.SetAttackCommand(false);
    }
}

