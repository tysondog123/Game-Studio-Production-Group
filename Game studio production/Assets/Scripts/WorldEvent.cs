using UnityEngine;

public class WorldEvent : Interactable
{

    public int ID;
    public override void Interact(PlayerControls player)
    {
        player.gameController.loopManager.ActivateEvent(ID);
        this.enabled = false;
        //Destroy(gameObject);
    }
}
