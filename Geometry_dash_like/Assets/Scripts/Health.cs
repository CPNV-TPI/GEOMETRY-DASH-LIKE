using UnityEngine;

public class Health : MonoBehaviour
{
    private const float HealingDuration = 30f;
    private const int MaximumHearts  = 3;
    
    private float _healingTimer;
    private HealthUI _healthUI;
    
    public int Hearts { get; private set; } = MaximumHearts;
    

    private void Awake()
    {
        _healthUI = GameObject.Find("Main Camera").GetComponent<HealthUI>();
        _healthUI.InitializeHearts(MaximumHearts);
    }

    private void Update()
    {
        if (Hearts == MaximumHearts) return;
        _healingTimer -= Time.deltaTime;
        if (_healingTimer <= 0) AddHealth();
    }

    public void RemoveHealth()
    {
        Hearts--;
        _healthUI.UpdateHeart(Hearts);
        ResetHealingTimer();
    }

    private void AddHealth()
    {
        Hearts++;
        _healthUI.UpdateHeart(Hearts);
        ResetHealingTimer();
    }

    private void ResetHealingTimer()
    {
        _healingTimer = HealingDuration;
    }
}