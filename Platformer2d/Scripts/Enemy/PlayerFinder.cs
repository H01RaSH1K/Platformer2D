using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerFinder : MonoBehaviour
{
    private readonly List<Player> _playersIn = new();

    public Player CurrentTarget => _playersIn.Count > 0 ? _playersIn[0] : null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            _playersIn.Add(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            _playersIn.Remove(player);
    }
}
