using System;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] private GameStateManager gameState;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Terminal terminal;
    [SerializeField] private string[] objectives =
    {
        "Find the security access card",
        "Access the security terminal",
        "Activate containment",
        "Escape the facility"
    };

    private int index;

    public event Action<string> ObjectiveChanged;

    public string CurrentText => index < objectives.Length ? objectives[index] : string.Empty;

    private void OnEnable()
    {
        inventory.ItemAdded += OnItemAdded;
        terminal.Accessed += OnTerminalAccessed;
        gameState.StateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        inventory.ItemAdded -= OnItemAdded;
        terminal.Accessed -= OnTerminalAccessed;
        gameState.StateChanged -= OnStateChanged;
    }

    private void Start()
    {
        ObjectiveChanged?.Invoke(CurrentText);
    }

    private void OnItemAdded(ItemId item)
    {
        if (item == ItemId.AccessCard)
        {
            CompleteIfCurrent(0);
        }
    }

    private void OnTerminalAccessed()
    {
        CompleteIfCurrent(1);
    }

    private void OnStateChanged(GameState state)
    {
        if (state == GameState.Alarm)
        {
            CompleteIfCurrent(2);
        }
    }

    private void CompleteIfCurrent(int expectedIndex)
    {
        if (index != expectedIndex)
        {
            return;
        }

        index++;
        Debug.Log($"Objective: {CurrentText}");
        ObjectiveChanged?.Invoke(CurrentText);
    }
}