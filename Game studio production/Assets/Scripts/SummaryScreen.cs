using UnityEditor.EditorTools;
using UnityEngine;

public class SummaryScreen : MonoBehaviour
{
    [SerializeField]
    MemoryController memoryController;
    [SerializeField]
    GameObject Canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        memoryController = FindFirstObjectByType<MemoryController>();
        Debug.Log(memoryController);
        memoryController.LoadCurrentMemories(Canvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
