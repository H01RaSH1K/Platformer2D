using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class VampirismRadiusView : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer> ();
    }

    private void OnEnable()
    {
        _vampirism.Enabled += OnVampirismEnabled;
        _vampirism.Disabled += OnVampirismDisabled;
        OnVampirismDisabled();
    }

    private void OnDisable()
    {
        _vampirism.Enabled -= OnVampirismEnabled;
        _vampirism.Disabled -= OnVampirismDisabled;
    }

    private void OnVampirismEnabled()
    {
        float scale = _vampirism.Radius * 2;
        transform.localScale = new Vector2(scale, scale);
        _renderer.enabled = true;
    }

    private void OnVampirismDisabled()
    {
        _renderer.enabled = false;
    }
}
