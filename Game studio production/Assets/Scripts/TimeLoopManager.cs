using Ink.Parsed;
using UnityEngine;
using System.Collections.Generic;

public class TimeLoopManager : MonoBehaviour
{
    static TimeLoopManager self;
    [SerializeField]
    GameController gameController;
    [SerializeField]
    EventRefs[] Events;
    [SerializeField]
    int sanity;
    [SerializeField]
    int actions = 7;
    public bool CheckEventStatus(int UID)
    {
        foreach (EventRefs E in Events)
        {
            if (E.HasHappend == true &&E.GetUID() ==UID)
            {
                return E.HasHappend;
            }
        }
        return false;
    }

    public void NewDay()
    {
        gameController = FindFirstObjectByType<GameController>();
        Inventory inventory = gameController.player.inventory;
        foreach (EventRefs E in Events)
        {
            if (E.HasHappend == true && inventory.IsKeyItem(E.GetUID()))
            {
                inventory.ObtainItem(E.GetUID());
            }
        }
        actions = 7;
    }
    public void ActivateEvent(int UID)
    {
       foreach (EventRefs E in Events)
       {
            if (E.GetUID() == UID && !E.HasHappend)
            {
                E.SetHasHappend();
                gameController.player.inventory.ObtainItem(UID);
                break;
            }
       }
    }

    private void Awake()
    {
        if (self == null)
        {
            self = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
   
    // Update is called once per frame
    public int GetActionCount()
    {
        return actions;
    }
    public void RemoveAction()
    {
        actions--;
        if (actions <= 0)
        {
            //for(int i =0;i< gameController.player.inventory.;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            gameController.sceneSwaper.SwapScene("End Of Day");
        }
        else
        {
            gameController.Sun.transform.eulerAngles = gameController.SunPos[actions - 1];
            gameController.AmuletActions[actions].SetActive(false);
        }
    }
}
