using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Item
{
    protected override void AcceptCollector(IItemCollector collector)
    {
        collector.CollectGem();
    }
}
