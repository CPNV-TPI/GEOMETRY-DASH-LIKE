using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void HealthChangeAction(int currentHealth);

    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            if (_instance != null) return _instance;
            ;
            _instance = FindObjectOfType<EventManager>();

            if (_instance != null) return _instance;
            var emptyObject = new GameObject();
            emptyObject.name = nameof(EventManager);
            _instance = emptyObject.AddComponent<EventManager>();


            return _instance;
        }
    }

    public event HealthChangeAction OnHealthChanged;

    public void TriggerHealthChanged(int currentHealth)
    {
        OnHealthChanged?.Invoke(currentHealth);
    }
}