using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemId item;
    [SerializeField] private string displayName = "Access Card";

    public string Prompt => $"Pick up {displayName}";

    public void Interact(GameObject interactor)
    {
        if (!interactor.TryGetComponent(out Inventory inventory))
        {
            Debug.LogWarning($"{interactor.name} has no Inventory, cannot pick up {displayName}");
            return;
        }

        inventory.Add(item);
        Destroy(gameObject);
    }
}