using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public event Action Collected;

    public void OnCollected(ItemCollector collector)
    {
        Collected?.Invoke();
        AcceptCollector(collector);
    }

    protected abstract void AcceptCollector(IItemCollector collector);
}