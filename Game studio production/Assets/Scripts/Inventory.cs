using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    int inventroySize = 1;
    [SerializeField]
    private GameObject[] _items;
    private void Start()
    {
        _items = new GameObject[inventroySize];
        
    }


    // this function is useed to add items to the private variable _items, following this method stops items from being acidently over writen
    public bool AddToInventory(GameObject Item)
    {
        // this for loop itterated through the _items array checking for empty slot's adding the object to the array if it finds one and then exiting the for loop
        bool added=false;
        for (int i = 0; i < _items.Length &&!added; i++)
        {
            if (_items[i]==null)
            {
                _items[i] = Item;
                added = true;
            }

        }

        // these returns are used for error protection, returning a true or false based on success to whatever called it
        if (added)
        {
            return true;
        }
        else
        {
            Debug.Log("Inventory full");
            return false;
        }
    }
    // this function is used to find an item at a specific index of the inventory returning a refrence if it isnt null
    public GameObject GetItem(int index)
    {
        if (_items[index]!= null)
        {
            return _items[index];
        }
        else
        {
            return null;
        }
    }
}
