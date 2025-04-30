using System;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        _health = Math.Max(_health - damage, 0);
    }

    public void Heal(int healthAmount)
    {
        _health += healthAmount;
    }
}
