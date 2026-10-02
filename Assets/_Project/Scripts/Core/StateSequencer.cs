using System.Collections;
using UnityEngine;

public class StateSequencer : MonoBehaviour
{
    [SerializeField] private GameStateManager manager;
    [SerializeField] private float alarmDuration = 3f;
    [SerializeField] private float containmentDuration = 10f;

    private Coroutine running;

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
        if (running != null)
        {
            StopCoroutine(running);
            running = null;
        }

        switch (state)
        {
            case GameState.Alarm:
                running = StartCoroutine(AdvanceAfter(alarmDuration, GameState.ContainmentActive));
                break;
            case GameState.ContainmentActive:
                running = StartCoroutine(AdvanceAfter(containmentDuration, GameState.Escape));
                break;
        }
    }

    private IEnumerator AdvanceAfter(float seconds, GameState next)
    {
        yield return new WaitForSeconds(seconds);
        manager.SetState(next);
    }
}