using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
class ItemsVar 
{

    [SerializeField]
    string name;

    [SerializeField, TextArea(1,3)]
    string description;
    public bool active { get; private set; }
    [SerializeField]
    bool keyItem;
    [SerializeField]
    int UID;

    [SerializeField]
    GameObject itemRef;
    
    public bool IsKeyItem()
    {
        return keyItem;
    }
    public int GetUID()
    {
        return UID;
    }
    public bool SetActive()
    {
        if (itemRef != null)
        {
            itemRef.SetActive(active);
            return true;
        }
        return false;
    }
    public void Obtained(bool State)
    {
        active = State;
    }
}
