using UnityEngine;

public class PlayerInputHandler : IInputHandler
{
    private Character character;

    public PlayerInputHandler(Character character)
    {
        this.character = character;
    }

    public Vector3 GetMovementInput()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        return direction;
    }

    public bool GetAttackInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}

