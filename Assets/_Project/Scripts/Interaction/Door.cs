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

    public void Unlock()
    {
        if (state == DoorState.Locked)
        {
            state = DoorState.Closed;
        }
    }

    public void Lock()
    {
        SetOpen(false);
        state = DoorState.Locked;
    }

    private void TryUnlock(GameObject interactor)
    {
        if (!requiresCard)
        {
            FeedbackChannel.Show("This door is locked");
            return;
        }

        if (interactor.TryGetComponent(out Inventory inventory) && inventory.Has(ItemId.AccessCard))
        {
            Debug.Log("Door unlocked with Access Card");
            FeedbackChannel.Show("Access granted");
            SetOpen(true);
        }
        else
        {
            FeedbackChannel.Show("Requires Access Card");
        }
    }

    private void SetOpen(bool open)
    {
        state = open ? DoorState.Open : DoorState.Closed;
        transform.position = open ? closedPosition + Vector3.up * openHeight : closedPosition;
    }
}