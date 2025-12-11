using UnityEngine;

public enum AIStateType
{
    Idle,
    Chase,
    Attack
}

public abstract class AIState
{
    protected Enemy enemy;
    protected AIStateType stateType;

    public AIState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public AIStateType GetStateType()
    {
        return stateType;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

