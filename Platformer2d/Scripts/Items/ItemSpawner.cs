using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item _prefab;
    [SerializeField] private float _spawnInterval;

    private Item _item;
    private WaitForSeconds _waitForSpawn;

    private void Awake()
    {
        _item = Instantiate(_prefab, transform);
        _waitForSpawn = new WaitForSeconds(_spawnInterval);
    }

    private void OnEnable()
    {
        _item.Collected += OnItemCollected;
    }

    private void OnDisable()
    {
        _item.Collected -= OnItemCollected;
    }

    private void OnItemCollected()
    {
        StartCoroutine(DisableItemTemporarily());
    }

    private IEnumerator DisableItemTemporarily()
    {
        _item.gameObject.SetActive(false);

        yield return _waitForSpawn;

        _item.gameObject.SetActive(true);
    }
}
