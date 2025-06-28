using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VampirismChargeBar : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism; 
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _vampirism.ChargeChanged += OnChargeChanged;
        OnChargeChanged();
    }

    private void OnDisable()
    {
        _vampirism.ChargeChanged -= OnChargeChanged;
    }

    private void OnChargeChanged()
    {
        _slider.value = GetNormalizedCharge();
    }

    private float GetNormalizedCharge()
    {
        return (float)_vampirism.Charge / _vampirism.MaxCharge;
    }
}
