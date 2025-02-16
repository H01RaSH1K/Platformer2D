using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Item
{
    [SerializeField] private int _healAmount = 30;
    
    public int HealAmount => _healAmount;

    protected override void AcceptCollector(ItemCollector collector)
    {
        collector.CollectCherry(this);
    }
}
