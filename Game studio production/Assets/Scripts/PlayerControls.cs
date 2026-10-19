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

    [SerializeField]
    public InputActionReference moveAction;
    [SerializeField]
    GameObject itemHoldPos;

    Inventory inventory;

    [SerializeField]
    GameObject UI;
    GameObject Holding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        // this is the players directional input
        Vector3 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = transform.right * input.x + transform.forward * input.y;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    // this function sets the parent of object in the array _items from inventory.cs
    //at the index to the holdpos varriable and sets its transforms pos and rot to be the same
    public void HoldObject(int index)
    {
        Holding = inventory.GetItem(index);
        if (Holding != null)
        {
            Holding.transform.parent = itemHoldPos.transform;
            Holding.transform.position=itemHoldPos.transform.position;
            Holding.transform.rotation = itemHoldPos.transform.rotation;
        }
    }

    // this function returns the item being held to the invetorys item pool, disconecting the object aswell

    public void ReturnItem(InputAction.CallbackContext context)
    {
        if (Holding!=null)
        {
            Holding.gameObject.transform.position = new Vector3(0, -10, 0);
            Holding.transform.parent = null;
            Holding = null;
        }
    }

    // this function toggles the temp inventory UI
    public void InventoryUI()
    {
        if (UI.activeInHierarchy)
        {
            UI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            UI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            UI.GetComponent<UIController>().UpdateUI();
        }
    }

    // this function shoots a raycast from the players pov forward to check for objects with the tag "Collectible",
    // if it hits one it attempts to add it to the inventory. this function is only called when the action interact happens (or E is pressed)
    public void Interact(InputAction.CallbackContext context)
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5f) && hit.collider.CompareTag("Collectible"))
        {
            if (inventory.AddToInventory(hit.collider.gameObject))
            {
                    hit.collider.gameObject.transform.position = new Vector3(0,-10,0);
            }
        }
    }

    // this function takes the mouse's input to rotate the player and the camera accordingly
    public void MouseLook(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>();
        float mouseX = mouseDelta.x * sensitivity * Time.deltaTime; 
        float mouseY = mouseDelta.y * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
        // Rotate the camera around the X-axis (vertical rotation)
        // this line clamps the angle the player can look up and down
        xRotation = Mathf.Clamp(xRotation + (Vector3.left * mouseY).x, -90f, 90f);
        playerCamera.transform.rotation = Quaternion.Euler(xRotation,transform.eulerAngles.y,transform.eulerAngles.z);
    }
}
