using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseAction;
    [SerializeField] private GameObject panel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private MonoBehaviour[] playerScriptsToDisable;

    private bool paused;

    private void Awake()
    {
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(Quit);
        panel.SetActive(false);
    }

    private void OnEnable()
    {
        pauseAction.action.Enable();
    }

    private void OnDisable()
    {
        if (pauseAction != null)
        {
            pauseAction.action.Disable();
        }
    }

    private void Update()
    {
        if (pauseAction.action.WasPressedThisFrame())
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        paused = true;
        panel.SetActive(true);
        Time.timeScale = 0f;
        SetPlayerControl(false);
    }

    private void Resume()
    {
        paused = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
        SetPlayerControl(true);
    }

    private void Quit()
    {
        Time.timeScale = 1f;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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