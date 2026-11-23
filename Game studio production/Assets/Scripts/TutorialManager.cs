using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    GameController gameController;
    [SerializeField]
    PlayerControls player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EnterKeyArea(GameObject Inviswall)
    {

    }
    public void Teleport(GameObject goal)
    {
        Debug.Log("tp");
        player.CanMove = false;
        player.transform.position = goal.transform.position;
        player.CanMove = true;
    }
}
