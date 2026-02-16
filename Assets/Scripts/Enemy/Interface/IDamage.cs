using UnityEngine;

public interface IDamage
{
    void Damage(float damageAmout);

    void Die();

    float MaxHealth { get; set; }

    float CurrentHealth { get; set; }

    float damage { get; set; }

}
