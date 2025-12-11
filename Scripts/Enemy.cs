using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float health = 50f;
    [SerializeField] private float maxHealth = 50f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackDamage = 15f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float detectionRange = 8f;
    [SerializeField] private Transform player;

    private AIStateMachine stateMachine;
    private NPCInputHandler npcInputHandler;

    protected override void InitializeCharacter()
    {
        characterData = new CharacterData(health, maxHealth, moveSpeed, attackDamage, attackRange, detectionRange);
        npcInputHandler = new NPCInputHandler(this);
        inputHandler = npcInputHandler;
        
        if (player != null)
        {
            SetTarget(player);
        }

        stateMachine = new AIStateMachine(this);
    }

    protected override void Update()
    {
        if (characterData.IsAlive())
        {
            stateMachine.Update();
            HandleMovement();
        }
    }

    public void ChangeState(AIStateType newState)
    {
        stateMachine.ChangeState(newState);
    }

    public AIStateType GetCurrentState()
    {
        return stateMachine.GetCurrentStateType();
    }

    public void PerformAttack()
    {
        Attack();
    }

    public override void Attack()
    {
        base.Attack();

        if (targetTransform != null)
        {
            Player player = targetTransform.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(characterData.AttackDamage);
            }
        }
    }

    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
    }

    public NPCInputHandler GetInputHandler()
    {
        return npcInputHandler;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

