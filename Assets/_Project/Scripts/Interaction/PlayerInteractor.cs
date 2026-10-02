using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private InputActionReference interactAction;
    [SerializeField] private float interactDistance = 3f;

    private IInteractable current;

    public IInteractable Current => current;

    private void OnEnable()
    {
        interactAction.action.Enable();
    }

    private void OnDisable()
    {
        if (interactAction != null)
        {
            interactAction.action.Disable();
        }
    }

    private void Update()
    {
        current = FindInteractable();

        if (current != null && interactAction.action.WasPressedThisFrame())
        {
            current.Interact(gameObject);
        }
    }

    private IInteractable FindInteractable()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                return interactable;
            }
        }

        return null;
    }
}