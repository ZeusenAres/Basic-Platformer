using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private List<Item> inventory = new List<Item>();

    public void addToInventory(Item item)
    {

        inventory.Add(item);
        //Debug.Log(inventory.Count);
    }
    public List<Item> getInventory()
    { 
        
        return inventory;
    }
}
