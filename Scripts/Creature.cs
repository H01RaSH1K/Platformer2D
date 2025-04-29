using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private int _hp;

    public void TakeDamage(int damage)
    {
        _hp = Math.Max(_hp - damage, 0);
    }

    public void Heal(int healthAmount)
    {
        _hp += healthAmount;
    }
}
