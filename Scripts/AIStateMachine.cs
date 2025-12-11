using UnityEngine;
using System.Collections.Generic;

public class AIStateMachine
{
    private Dictionary<AIStateType, AIState> states;
    private AIState currentState;
    private Enemy enemy;

    public AIStateMachine(Enemy enemy)
    {
        this.enemy = enemy;
        states = new Dictionary<AIStateType, AIState>();
        InitializeStates();
    }

    private void InitializeStates()
    {
        states.Add(AIStateType.Idle, new IdleState(enemy));
        states.Add(AIStateType.Chase, new ChaseState(enemy));
        states.Add(AIStateType.Attack, new AttackState(enemy));

        currentState = states[AIStateType.Idle];
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }

    public void ChangeState(AIStateType newStateType)
    {
        if (currentState != null && currentState.GetStateType() == newStateType)
        {
            return;
        }

        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = states[newStateType];
        currentState.Enter();
    }

    public AIStateType GetCurrentStateType()
    {
        return currentState.GetStateType();
    }
}

