using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GemsCounter _gemsCounter;
    [SerializeField] private EntityStats _entityStats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Item item))
            item.OnCollected(this);
    }

    public void CollectGem()
    {
        _gemsCounter.AddGem();
    }

    public void CollectCherry(Cherry cherry)
    {
        _entityStats.Heal(cherry.HealAmount);
    }
}
