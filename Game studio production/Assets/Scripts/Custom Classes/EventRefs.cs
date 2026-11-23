using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
class EventRefs 
{
    [SerializeField]
    string name;
    [SerializeField, TextArea(1, 3)]
    string description;
    [SerializeField]
    int UID;
    public bool HasHappend { get; private set; } = false;
    [SerializeField]
    UnityEvent e_Event = new UnityEvent();
    public int GetUID()
    {
        return UID;
    }
    public string GetName()
    {
        return name;
    }
    public void SetHasHappend()
    {
        HasHappend = true;
        if (e_Event != null)
        {
            e_Event.Invoke();
        }
    }
}
