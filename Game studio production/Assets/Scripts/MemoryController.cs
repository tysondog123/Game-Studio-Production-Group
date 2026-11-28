using TMPro;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class MemoryController : MonoBehaviour
{
    [SerializeField]
    Transform scrollRect;
    [SerializeField]
    GameObject TextItem;
    TimeLoopManager loopManager;
    [SerializeField]
    Memory[] memories;

    void Start()
    {
        loopManager = FindFirstObjectByType<TimeLoopManager>();
        LoadAllMemories();
    }
    public void LoadCurrentMemories()
    {

    }
    public void LoadAllMemories()
    {
        string memoryText;
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
    public void AddMemory(string memoryText)
    {
        TextMeshProUGUI TextBox= Instantiate(TextItem, scrollRect).GetComponent<TextMeshProUGUI>();
        TextBox.text = memoryText;
    } 
     
}
