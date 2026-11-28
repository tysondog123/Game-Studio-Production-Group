using TMPro;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class MemoryController : MonoBehaviour
{
    public Transform scrollRect;
    [SerializeField]
    GameObject TextItem;
    TimeLoopManager loopManager;
    [SerializeField]
    GameObject MemoryMenuPrefab;
    GameObject spawnedMemoryMenu;
    [SerializeField]
    Memory[] memories;


    void Start()
    {
        loopManager = FindFirstObjectByType<TimeLoopManager>();
    }
    public void LoadCurrentMemories(GameObject MemoryCanvas)
    {
        string memoryText;
        OpenMemoryUI(MemoryCanvas);
        foreach (Memory memory in memories)
        {
            if (loopManager.CheckEventStatus(memory.UID)&&loopManager.EventsThisLoop.Contains(memory.UID))
            {
                int ConnectionCount = 0;
                memoryText = $"{memory.Start}";
                foreach (MemoryConnection connection in memory.Connections)
                {
                    if (loopManager.CheckEventStatus(connection.refrenceEvent))
                    {
                        Debug.Log(connection.refrenceEvent);
                        memoryText = $"{memoryText} {connection.MemoryText}";
                        ConnectionCount++;
                    }
                }
                if (ConnectionCount < memory.Connections.Length)
                {
                    memoryText = $"{memoryText} but i feel like theres something else i need to do";
                }
                AddMemory(memoryText);
            }

        }
    }
    public void LoadAllMemories(GameObject MemoryCanvas)
    {
        string memoryText;
        OpenMemoryUI(MemoryCanvas);
        foreach(Memory memory in memories)
        {
            if (loopManager.CheckEventStatus(memory.UID))
            {
                int ConnectionCount=0;
                memoryText = $"{memory.Start}";
                foreach (MemoryConnection connection in memory.Connections)
                {
                    if (loopManager.CheckEventStatus(connection.refrenceEvent))
                    {
                        Debug.Log(connection.refrenceEvent);
                        memoryText = $"{memoryText} {connection.MemoryText}";
                        ConnectionCount++;
                    }
                }
                if (ConnectionCount < memory.Connections.Length)
                {
                    memoryText = $"{memoryText} but i feel like theres something else i need to do";
                }
                AddMemory(memoryText);
            }
            
        }
    }
    void OpenMemoryUI(GameObject SummaryCanvas)
    {
        spawnedMemoryMenu = Instantiate(MemoryMenuPrefab, SummaryCanvas.transform);
        scrollRect = spawnedMemoryMenu.transform.GetChild(0).GetChild(0).GetChild(0);
    }
    public void AddMemory(string memoryText)
    {
        TextMeshProUGUI TextBox= Instantiate(TextItem, scrollRect).GetComponent<TextMeshProUGUI>();
        TextBox.text = memoryText;
    } 
     
}
