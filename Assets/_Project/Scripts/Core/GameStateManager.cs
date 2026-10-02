using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameState initialState = GameState.Normal;

    public GameState Current { get; private set; }

    public event Action<GameState> StateChanged;

    private void Start()
    {
        SetState(initialState);
    }

    public void SetState(GameState newState)
    {
        Current = newState;
        Debug.Log($"GameState: {newState}");
        StateChanged?.Invoke(newState);
    }
}