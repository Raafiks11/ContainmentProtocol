using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    [SerializeField] private GameStateManager manager;

    private bool used;

    public string Prompt => used ? "Terminal (offline)" : "Use terminal";

    public void Interact(GameObject interactor)
    {
        Activate();
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