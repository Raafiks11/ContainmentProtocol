using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button activateButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private MonoBehaviour[] playerScriptsToDisable;

    private Terminal currentTerminal;

    private void Awake()
    {
        activateButton.onClick.AddListener(OnActivateClicked);
        closeButton.onClick.AddListener(Close);
        panel.SetActive(false);
    }

    public void Open(Terminal terminal)
    {
        currentTerminal = terminal;
        panel.SetActive(true);
        SetPlayerControl(false);
    }

    public void Close()
    {
        panel.SetActive(false);
        SetPlayerControl(true);
    }

    private void OnActivateClicked()
    {
        currentTerminal.Activate();
        Close();
    }

    private void SetPlayerControl(bool enabled)
    {
        foreach (MonoBehaviour script in playerScriptsToDisable)
        {
            script.enabled = enabled;
        }

        Cursor.lockState = enabled ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !enabled;
    }
}