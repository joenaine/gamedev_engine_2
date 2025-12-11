using UnityEngine;

public class NPCInputHandler : IInputHandler
{
    private Character character;
    private bool shouldAttack;

    public NPCInputHandler(Character character)
    {
        this.character = character;
        shouldAttack = false;
    }

    public Vector3 GetMovementInput()
    {
        if (character.GetTarget() == null)
        {
            return Vector3.zero;
        }

        Vector3 direction = character.GetTarget().position - character.transform.position;
        direction.y = 0;
        return direction.normalized;
    }

    public bool GetAttackInput()
    {
        return shouldAttack;
    }

    public void SetAttackCommand(bool attack)
    {
        shouldAttack = attack;
    }
}

