using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    GameObject playerCamera;
    [SerializeField]
    float sensitivity = 1;
    [SerializeField]
    float moveSpeed = 5f;
    float xRotation = 0f;

    public InputActionReference moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = transform.right * input.x + transform.forward * input.y;
        transform.position += move * moveSpeed * Time.deltaTime;
    }
    public void MouseLook(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>();
        float mouseX = mouseDelta.x * sensitivity * Time.deltaTime; 
        float mouseY = mouseDelta.y * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
        // Rotate the camera around the X-axis (vertical rotation)
        xRotation = Mathf.Clamp(xRotation + (Vector3.left * mouseY).x, -90f, 90f);
        playerCamera.transform.rotation = Quaternion.Euler(xRotation,transform.eulerAngles.y,transform.eulerAngles.z);
    }
}
