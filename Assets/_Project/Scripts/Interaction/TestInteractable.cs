using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
    public string Prompt => "Test object";

    public void Interact(GameObject interactor)
    {
        Debug.Log($"{interactor.name} interacted with {name}");
    }
}