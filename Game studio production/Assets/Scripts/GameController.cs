using Ink.UnityIntegration;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField]
    DialogController dialogUI;
    [SerializeField]
    public TimeLoopManager loopManager;
    [SerializeField]
    public PlayerControls player;
    [SerializeField]
    public SceneSwaper sceneSwaper;
    [SerializeField]
    public GameObject Sun;
    [SerializeField]
    public Vector2[] SunPos;
    //temp 
    public GameObject[] AmuletActions;
    private void Awake()
    {
        loopManager = FindFirstObjectByType<TimeLoopManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OpenDialog(NPC NPC)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        dialogUI.gameObject.SetActive(true);
        dialogUI.SetNPC(NPC);
        dialogUI.StartDialog();
    }
    public void CloseDialog()
    {
        if (loopManager.GetActionCount() > 0)
        {
            dialogUI.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player.CanMove = true;
        }
    }

}
