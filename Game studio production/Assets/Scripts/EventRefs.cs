using System;
using UnityEngine;

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
    }
}
