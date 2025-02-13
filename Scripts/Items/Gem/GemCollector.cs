using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GemCollector : ItemCollector<Gem>
{
    [SerializeField] private GemsCounter _gemsCounter;

    protected override void Collect(Gem gem)
    {
        _gemsCounter.AddGem();
    }
}
