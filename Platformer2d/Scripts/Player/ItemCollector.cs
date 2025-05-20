using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemCollector : MonoBehaviour, IItemCollector
{
    [SerializeField] private Health _health;
    [SerializeField] private GemsCounter _gemsCounter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
            item.BeCollected(this);
    }

    public void CollectGem()
    {
        _gemsCounter.AddGem();
    }

    public void CollectCherry(Cherry cherry)
    {
        _health.TakeHeal(cherry.HealAmount);
    }
}
