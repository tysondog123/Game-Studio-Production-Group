using UnityEngine;

public class Items : Interactable
{
    public int ID;
    public override void Interact(PlayerControls player)
    {
        player.inventory.ObtainItem(ID);
        Destroy(gameObject);
    }
}
