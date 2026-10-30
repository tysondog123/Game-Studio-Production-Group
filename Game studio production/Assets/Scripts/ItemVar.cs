using System;
using UnityEngine;

[Serializable]
class ItemsVar
{
    public bool active;
    [SerializeField]
    int UID;
    public GameObject itemRef;
    public int GetUID()
    {
        return UID;
    }
}
