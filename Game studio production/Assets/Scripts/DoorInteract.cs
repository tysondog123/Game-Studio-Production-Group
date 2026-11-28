using UnityEngine;
using UnityEngine.Events;

public class DoorInteract : Interactable
{
    [SerializeField]
    UnityEvent e_DoorOpen;
    public override void Interact(PlayerControls player)
    {
        e_DoorOpen.Invoke(); 
    }
}
