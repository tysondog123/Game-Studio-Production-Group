using Ink.Runtime;
using Ink.UnityIntegration;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class NPC : Interactable
{
    public string NPCName;
    [SerializeField]
    UnityEvent e_Event = new UnityEvent();
    public override void Interact(PlayerControls player)
    {
        e_Event.Invoke();
        player.CanMove = false;
    }
    [SerializeField]
    InkFile StandardDialog;
    [SerializeField]
    int TimesSpokenTo=0;
    [SerializeField]
    int PartsCompleted = 0;
    public InkFile GetInkFile()
    {
        return StandardDialog;
    }
    public void Save(int Item,int Value)
    {
        switch (Item)
        {
            case 0:
                SetTimesSpokenTo(Value);
                break;
            case 1:
                SetPartsCompleted(Value);
                break;
            default:
                break;
        }

    }
    public int GetTimesSpokenTo()
    {
        return TimesSpokenTo;
    }
    public void SetTimesSpokenTo(int Value)
    {
        TimesSpokenTo=Value;
    }
    public int GetPartsCompleted()
    {
        return PartsCompleted;
    }
    public void SetPartsCompleted(int Value)
    {
        PartsCompleted = Value;
    }
}
