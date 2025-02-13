using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ItemCollector<T> : MonoBehaviour where T : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out T item))
        {
            Collect(item);
            item.OnCollected();
        }
    }

    protected abstract void Collect(T item);
}
