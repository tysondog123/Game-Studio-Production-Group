using TMPro;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    GameController gameController;
    [SerializeField]
    GameObject PauseMenu;
    [SerializeField]
    GameObject convoHistoryUI;
    GameObject ConvohistoryUI;
    Transform conversationHistory;
    [SerializeField]
    TextMeshProUGUI BlankText;
    public void ToggelPause()
    {
        if (PauseMenu.activeInHierarchy)
        {
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            //Destroy(spawnedMemoryMenu);
            Destroy(ConvohistoryUI);
        }
        else
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        } 
    }

    public void OpenMemories()
    {
        gameController.memoryController.LoadAllMemories(PauseMenu);
    }
    public void DialogHistory()
    {
        if (ConvohistoryUI != null)
        {
            Destroy(ConvohistoryUI);
        }
        ConvohistoryUI = Instantiate(convoHistoryUI, PauseMenu.transform).gameObject;
        conversationHistory = ConvohistoryUI.transform.GetChild(0).GetChild(0).GetChild(0);
        foreach (string dialogLine in gameController.dialogUI.FullPastConvo)
        {
            TextMeshProUGUI Spawned = Instantiate(BlankText, conversationHistory);
            Spawned.text = dialogLine;
        }
    }
}
