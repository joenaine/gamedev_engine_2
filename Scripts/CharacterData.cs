using UnityEngine;

public class CharacterData
{
    private float health;
    private float maxHealth;
    private float moveSpeed;
    private float attackDamage;
    private float attackRange;
    private float detectionRange;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float AttackDamage { get { return attackDamage; } }
    public float AttackRange { get { return attackRange; } }
    public float DetectionRange { get { return detectionRange; } }

    public CharacterData(float health, float maxHealth, float moveSpeed, float attackDamage, float attackRange, float detectionRange)
    {
        this.health = health;
        this.maxHealth = maxHealth;
        this.moveSpeed = moveSpeed;
        this.attackDamage = attackDamage;
        this.attackRange = attackRange;
        this.detectionRange = detectionRange;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0) health = 0;
    }

    public void Heal(float amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}

