using System;
using UnityEngine;

public class GemsCounter : MonoBehaviour
{
    public event Action CountChanged;

    public int Count { get; private set; }

    public void AddGem()
    {
        Count++;
        CountChanged?.Invoke();
    }
}