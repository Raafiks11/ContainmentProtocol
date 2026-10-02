using UnityEngine;

public class StateDoorLock : MonoBehaviour
{
    [SerializeField] private GameStateManager manager;
    [SerializeField] private Door door;
    [SerializeField] private GameState unlockedInState = GameState.Escape;

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
        if (state == unlockedInState)
        {
            door.Unlock();
        }
        else
        {
            door.Lock();
        }
    }
}