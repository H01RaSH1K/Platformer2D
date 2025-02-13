using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public event Action Collected;

    public void OnCollected()
    {
        Collected?.Invoke();
    }
}