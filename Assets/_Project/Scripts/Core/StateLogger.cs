using UnityEngine;

public class StateLogger : MonoBehaviour
{
    [SerializeField] private GameStateManager manager;

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
        Debug.Log($"StateLogger heard: {state}");
    }
}