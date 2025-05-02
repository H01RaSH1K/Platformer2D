using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _count;

    public void TakeDamage(int damage)
    {
        if (damage >= 0)
            _count = Math.Max(_count - damage, 0);
    }

    public void Heal(int healthAmount)
    {
        if (healthAmount >= 0)
            _count += healthAmount;
    }
}
