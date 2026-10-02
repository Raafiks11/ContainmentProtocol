using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private InputActionReference lookAction;
    [SerializeField] private float sensitivity = 0.1f;
    [SerializeField] private float maxPitch = 85f;

    private float pitch;

    private void OnEnable()
    {
        lookAction.action.Enable();
    }

    private void OnDisable()
    {
        if (lookAction != null)
        {
            lookAction.action.Disable();
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 look = lookAction.action.ReadValue<Vector2>();

        float yaw = look.x * sensitivity;
        pitch -= look.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -maxPitch, maxPitch);

        transform.Rotate(0f, yaw, 0f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}