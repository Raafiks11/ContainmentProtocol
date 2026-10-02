using System.Collections;
using TMPro;
using UnityEngine;

public class FeedbackUI : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private float duration = 2f;

    private Coroutine running;

    private void Awake()
    {
        messageText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        FeedbackChannel.MessageRaised += OnMessage;
    }

    private void OnDisable()
    {
        FeedbackChannel.MessageRaised -= OnMessage;
    }

    private void OnMessage(string message)
    {
        if (running != null)
        {
            StopCoroutine(running);
        }

        running = StartCoroutine(ShowRoutine(message));
    }

    private IEnumerator ShowRoutine(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        messageText.gameObject.SetActive(false);
        running = null;
    }
}