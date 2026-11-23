using UnityEngine;

public class MultipleInteractionParent : MonoBehaviour
{
    GameObject[] Childern;
    int NumberInteracted;
    int interactGoal;
    [SerializeField]
    GameController gameController;
    [SerializeField]
    int EvetUID;
    private void Start()
    {
        interactGoal = transform.childCount+1;
    }
    public void Interact()
    {
        NumberInteracted++;
        if (NumberInteracted >= interactGoal)
        {
            gameController.loopManager.ActivateEvent(EvetUID);
        }
    }
}
