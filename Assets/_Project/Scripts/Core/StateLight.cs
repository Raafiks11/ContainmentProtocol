using UnityEngine;

public class StateLight : MonoBehaviour
{
    [SerializeField] private GameStateManager manager;
    [SerializeField] private Light targetLight;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color alarmColor = Color.red;
    [SerializeField] private Color containmentColor = new Color(1f, 0.5f, 0f);
    [SerializeField] private Color escapeColor = Color.green;

    private void OnEnable()
    {
        manager.StateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        manager.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged(GameState state)
    {
        targetLight.color = state switch
        {
            GameState.Alarm => alarmColor,
            GameState.ContainmentActive => containmentColor,
            GameState.Escape => escapeColor,
            _ => normalColor
        };
    }
}