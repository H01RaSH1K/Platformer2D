using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class HealthBar : HealthView
{
    protected Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    protected float GetNormalizedHealth()
    {
        return (float)Health.Count / Health.Max;
    }
}
