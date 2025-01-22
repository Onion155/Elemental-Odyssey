using UnityEngine;

public interface IDamageAble
{
    void Damage(float damageAmount);

    void Die();

    float MaxHealth {  get; set; }

    float CurrentHealth {  get; set; }
}
