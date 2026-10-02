using TMPro;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    [SerializeField] private ObjectiveManager manager;
    [SerializeField] private TMP_Text objectiveText;

    private void OnEnable()
    {
        manager.ObjectiveChanged += OnObjectiveChanged;
    }

    private void OnDisable()
    {
        manager.ObjectiveChanged -= OnObjectiveChanged;
    }

    private void OnObjectiveChanged(string text)
    {
        objectiveText.text = $"Objective: {text}";
    }
}