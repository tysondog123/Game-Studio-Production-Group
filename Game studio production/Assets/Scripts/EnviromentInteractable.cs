using UnityEngine;

public class EnviromentInteractable : Interactable
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    AnimationClip[] transition;
    [SerializeField]
    string paramaterName;
    bool state= true;
    public override void Interact(PlayerControls player)
    {
        if (state)
        {
            animator.Play(transition[0].name);
            state = false;
        }
        else
        {
            animator.Play(transition[1].name);
            state = true;
        }
    }
}
