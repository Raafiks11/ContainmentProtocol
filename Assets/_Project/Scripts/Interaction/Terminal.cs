using System;
using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    [SerializeField] private GameStateManager manager;
    [SerializeField] private TerminalUI ui;

    private bool used;

    public event Action Accessed;

    public string Prompt => used ? "Terminal (offline)" : "Use terminal";

    public void Interact(GameObject interactor)
    {
        if (used)
        {
            return;
        }

        Accessed?.Invoke();
        ui.Open(this);
    }

    public void Activate()
    {
        if (used)
        {
            return;
        }

        used = true;
        manager.SetState(GameState.Alarm);
    }
}