using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private EscapeZone escapeZone;
    [SerializeField] private GameObject panel;
    [SerializeField] private Button restartButton;
    [SerializeField] private MonoBehaviour[] playerScriptsToDisable;

    private void Awake()
    {
        restartButton.onClick.AddListener(Restart);
        panel.SetActive(false);
    }

    private void OnEnable()
    {
        escapeZone.PlayerEscaped += Show;
    }

    private void OnDisable()
    {
        escapeZone.PlayerEscaped -= Show;
    }

    private void Show()
    {
        panel.SetActive(true);

        foreach (MonoBehaviour script in playerScriptsToDisable)
        {
            script.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}