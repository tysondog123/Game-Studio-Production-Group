using Unity.Mathematics;
using UnityEngine;
using Ink.UnityIntegration;

public class GameController : MonoBehaviour
{
    [SerializeField]
    DialogController dialogUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void OpenDialog(InkFile DialogTree)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        dialogUI.gameObject.SetActive(true);
        dialogUI.inkFile = DialogTree;
        dialogUI.StartDialog();
    }
    public void CloseDialog()
    {

        dialogUI.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
