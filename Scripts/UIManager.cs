using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gemsText;

    private void OnEnable()
    {
        GameManager.Instance.GemsAmountChanged += OnGemsAmountChanged;
    }

    private void OnDisable()
    {

        GameManager.Instance.GemsAmountChanged -= OnGemsAmountChanged;
    }

    private void OnGemsAmountChanged()
    {
        _gemsText.text = GameManager.Instance.Gems.ToString();
    }
}
