using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected CharacterData characterData;
    protected IInputHandler inputHandler;
    protected Transform targetTransform;

    public CharacterData Data { get { return characterData; } }

    protected virtual void Start()
    {
        InitializeCharacter();
    }

    protected virtual void Update()
    {
        if (characterData.IsAlive())
        {
            HandleMovement();
            HandleActions();
        }
    }

    protected abstract void InitializeCharacter();

    protected virtual void HandleMovement()
    {
        if (inputHandler != null)
        {
            Vector3 direction = inputHandler.GetMovementInput();
            if (direction != Vector3.zero)
            {
                Move(direction);
            }
        }
    }

    protected virtual void HandleActions()
    {
        if (inputHandler != null && inputHandler.GetAttackInput())
        {
            Attack();
        }
    }

    protected virtual void Move(Vector3 direction)
    {
        transform.position += direction.normalized * characterData.MoveSpeed * Time.deltaTime;
    }

    public virtual void Attack()
    {
        Debug.Log($"{gameObject.name} attacks for {characterData.AttackDamage} damage");
    }

    public void TakeDamage(float damage)
    {
        characterData.TakeDamage(damage);
        if (!characterData.IsAlive())
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} has died");
    }

    public void SetTarget(Transform target)
    {
        targetTransform = target;
    }

    public Transform GetTarget()
    {
        return targetTransform;
    }

    public float GetDistanceToTarget()
    {
        if (targetTransform == null) return float.MaxValue;
        return Vector3.Distance(transform.position, targetTransform.position);
    }
}

