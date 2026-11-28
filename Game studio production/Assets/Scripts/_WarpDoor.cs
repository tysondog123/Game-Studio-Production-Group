using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class _WarpDoor : MonoBehaviour
{
    [SerializeField] private Renderer doorRenderer;

    [SerializeField] private Material normalMaterial;

    [SerializeField] private Material glowMaterial;

    [SerializeField] private GameObject interactionCanvas;

    [SerializeField] private TMP_Text interactionText;

    [SerializeField] private InputActionReference interactAction;

    [SerializeField] private Transform warpDestination;

    [SerializeField] private GameController gameController;

    private CharacterController playerController;

    private bool playerInRange;

    private InputAction playerInteractAction;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        doorRenderer.sharedMaterial = normalMaterial;

        interactionCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerController = other.GetComponentInParent<CharacterController>();

        PlayerInput playerInput = playerController.GetComponentInParent<PlayerInput>();

        playerInteractAction = playerInput != null
            ? playerInput.actions.FindAction(interactAction.action.id.ToString())
            : interactAction.action;

        playerInRange = true;

        doorRenderer.sharedMaterial = glowMaterial;

        interactionText.text =
            interactAction.action.GetBindingDisplayString();

        interactionCanvas.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = false;

        playerController = null;

        doorRenderer.sharedMaterial = normalMaterial;

        interactionCanvas.SetActive(false);

        playerInteractAction = null;
    }

    private void WarpPlayer()
    {
        if (!playerInRange || playerController == null)
            return;

        playerController.enabled = false;

        playerController.transform.position = warpDestination.position;

        playerController.enabled = true;

        playerInRange = false;

        playerController = null;
        
        playerInteractAction = null;

        doorRenderer.sharedMaterial = normalMaterial;
        
        interactionCanvas.SetActive(false);

        gameController.loopManager.RemoveAction();
    }

    private void Update()
    {
        if (!playerInRange || playerInteractAction == null)
            return;

        if (playerInteractAction.enabled && playerInteractAction.WasPerformedThisFrame())
        {
            WarpPlayer();
        }
    }
}
