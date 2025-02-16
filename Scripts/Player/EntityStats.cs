using System;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public int Health {get; private set;}

    private void Awake()
    {
        Health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health = Math.Max(Health - damage, 0);
    }

    public void Heal(int healthAmount)
    {
        Health = Math.Min(Health + healthAmount, _maxHealth);
    }
}
