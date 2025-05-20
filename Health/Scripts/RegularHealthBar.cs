public class RegularHealthBar : HealthBar
{
    protected override void OnHealthChanged()
    {
        Slider.value = GetNormalizedHealth();
    }
}
