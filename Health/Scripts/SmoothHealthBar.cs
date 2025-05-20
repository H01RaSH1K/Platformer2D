using System.Collections;
using UnityEngine;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private float _fillDelta = 0.01f;

    private Coroutine _fillingCoroutine;

    protected override void OnHealthChanged()
    {
        if (_fillingCoroutine == null)
            _fillingCoroutine = StartCoroutine(SmoothlyFill());
    }

    private IEnumerator SmoothlyFill()
    {
        float targetFill;

        do
        {
            targetFill = GetNormalizedHealth();
            Slider.value = Mathf.MoveTowards(Slider.value, targetFill, _fillDelta);
            yield return null;
        } while (Slider.value != targetFill);

        _fillingCoroutine = null;
    }
}
