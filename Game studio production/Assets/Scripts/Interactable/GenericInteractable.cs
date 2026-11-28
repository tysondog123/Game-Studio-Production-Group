using UnityEngine;
using UnityEngine.Events;

public class GenericInteractable : Interactable
{
    [SerializeField]
    UnityEvent e_interactionEvent;
    [SerializeField]
    bool DestroyAfterinteract;
    public override void Interact(PlayerControls player)
    {
        e_interactionEvent.Invoke();
        if (DestroyAfterinteract)
        {
            Destroy(gameObject);
        }
    }
}
