using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action GemsAmountChanged;

    public static GameManager Instance { get; private set; }

    public int Gems { get; private set; }

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
    }

    public void AddGem()
    {
        Gems++;
        GemsAmountChanged?.Invoke();
    }
}