using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResourceHandler : MonoBehaviour
{

    [SerializeField] Slider hungerBar;
    [SerializeField] Slider researchBar;
    //private HungerBar hunger;
    //private ResearchBar research;
    private PlayerInventory inventory;
    private bool isDestroyed;
    private Item item;

    private void Start()
    {

        inventory = GetComponent<PlayerInventory>();
        item = new Item();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (isDestroyed == true)
        {

            isDestroyed = false;
            return;
        }

        if (collision.gameObject.CompareTag("Food") || collision.gameObject.CompareTag("Research"))
        {

            //hunger.feed(20f);
            var item = collision.gameObject.GetComponent<ItemController>();
            this.item.sprite = item.getSprite();
            this.item.value = item.getValue();
            this.item.name = item.getName();
            inventory.addToInventory(this.item);
            isDestroyed = true;
            Destroy(collision.gameObject);
        }
    }

    public bool IsDestroyed()
    {

        return isDestroyed;
    }
}

public class Item
{

    public Sprite sprite;
    public float value;
    public string name;
}
