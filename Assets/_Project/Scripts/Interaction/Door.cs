using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public enum DoorState { Locked, Closed, Open }

    [SerializeField] private DoorState state = DoorState.Closed;
    [SerializeField] private bool requiresCard;
    [SerializeField] private float openHeight = 3f;

    private Vector3 closedPosition;

    public string Prompt => state switch
    {
        DoorState.Locked => "Door (locked)",
        DoorState.Closed => "Open door",
        _ => "Close door"
    };

    private void Awake()
    {
        closedPosition = transform.position;

        if (requiresCard)
        {
            state = DoorState.Locked;
        }
    }

    public void Interact(GameObject interactor)
    {
        switch (state)
        {
            case DoorState.Locked:
                TryUnlock(interactor);
                break;
            case DoorState.Closed:
                SetOpen(true);
                break;
            case DoorState.Open:
                SetOpen(false);
                break;
        }
    }

    private void TryUnlock(GameObject interactor)
    {
        if (interactor.TryGetComponent(out Inventory inventory) && inventory.Has(ItemId.AccessCard))
        {
            Debug.Log("Door unlocked with Access Card");
            SetOpen(true);
        }
        else
        {
            Debug.Log("Requires Access Card");
        }
    }

    private void SetOpen(bool open)
    {
        state = open ? DoorState.Open : DoorState.Closed;
        transform.position = open ? closedPosition + Vector3.up * openHeight : closedPosition;
    }
}