using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    [SerializeField] private PlayerInteractor interactor;
    [SerializeField] private TMP_Text promptText;

    private void Update()
    {
        IInteractable target = interactor.Current;

        if (target == null)
        {
            promptText.gameObject.SetActive(false);
            return;
        }

        promptText.text = $"[E] {target.Prompt}";
        promptText.gameObject.SetActive(true);
    }
}