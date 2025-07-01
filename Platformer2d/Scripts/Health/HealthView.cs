using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.Changed += OnHealthChanged;
        OnHealthChanged();
    }

    private void OnDisable()
    {
        Health.Changed -= OnHealthChanged;
    }

    protected abstract void OnHealthChanged();
}
