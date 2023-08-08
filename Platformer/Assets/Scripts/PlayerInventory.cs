using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private List<Item> inventory = new List<Item>();

    public void addToInventory(Item item)
    {

        if (inventory.Count == 0)
        {

            inventory.Add(item);
        }

        foreach (Item existingItem in inventory.ToList())
        {

            if (existingItem.name == item.name)
            {

                break;
            }

            if (existingItem.name != item.name)
            {

                inventory.Add(item);
                break;
            }
        }

        return;
        //Debug.Log(inventory.Count);
    }
    public List<Item> getInventory()
    { 
        
        return inventory;
    }
}
