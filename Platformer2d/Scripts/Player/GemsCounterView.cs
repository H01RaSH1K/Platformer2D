using TMPro;
using UnityEngine;

public class GemsCounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gemsText;
    [SerializeField] private GemsCounter _gemsCounter;

    private void OnEnable()
    {
        _gemsCounter.CountChanged += OnGemsAmountChanged;
    }

    private void OnDisable()
    {
        _gemsCounter.CountChanged -= OnGemsAmountChanged;
    }

    private void OnGemsAmountChanged()
    {
        _gemsText.text = _gemsCounter.Count.ToString();
    }
}

