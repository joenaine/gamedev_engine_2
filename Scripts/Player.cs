using UnityEngine;

public class Player : Character
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float detectionRange = 10f;

    protected override void InitializeCharacter()
    {
        characterData = new CharacterData(health, maxHealth, moveSpeed, attackDamage, attackRange, detectionRange);
        inputHandler = new PlayerInputHandler(this);
    }

    public override void Attack()
    {
        base.Attack();

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, characterData.AttackRange);
        foreach (Collider hitCollider in hitColliders)
        {
            Enemy enemy = hitCollider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(characterData.AttackDamage);
            }
        }
    }

    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
    }
}

