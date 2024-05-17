using UnityEngine;

public class Health : MonoBehaviour
{
    private const float HealingDuration = 30f;
    private const int MaximumHearts = 3;

    public int Hearts { get; private set; } = MaximumHearts;
    public float HealingTimer { get; private set; } = HealingDuration;

    private void Update()
    {
        if (Hearts == MaximumHearts) return;
        HealingTimer -= Time.deltaTime;
        if (HealingTimer <= 0) AddHealth();
    }

    public void RemoveHealth()
    {
        Hearts--;
        EventManager.Instance.TriggerHealthChanged(Hearts);
        ResetHealingTimer();
    }

    private void AddHealth()
    {
        Hearts++;
        EventManager.Instance.TriggerHealthChanged(Hearts);
        ResetHealingTimer();
    }

    private void ResetHealingTimer()
    {
        HealingTimer = HealingDuration;
    }
}