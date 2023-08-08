using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class PlayerResourceHandler : MonoBehaviour
{

    [SerializeField] Slider hungerBar;
    [SerializeField] Slider researchBar;
    private PlayerInventory inventory;
    private Item item;

    private void Start()
    {

        inventory = GetComponent<PlayerInventory>();
    }

    public void addToInventory(GameObject obj)
    {

        this.item = new Item();
        var item = obj.GetComponent<ItemController>();
        this.item.sprite = item.getSprite();
        this.item.value = item.getValue();
        this.item.name = item.getName();
        inventory.addToInventory(this.item);
    }
}

public class Item
{

    public Sprite sprite;
    public float value;
    public string name;
}
