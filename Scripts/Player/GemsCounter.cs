using System;
using UnityEngine;

public class GemsCounter : MonoBehaviour
{
    public event Action GemsAmountChanged;

    public int Gems { get; private set; }

    public void AddGem()
    {
        Gems++;
        GemsAmountChanged?.Invoke();
    }
}