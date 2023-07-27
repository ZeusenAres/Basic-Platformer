using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    [SerializeField] GameObject player;
    private PlayerResourceHandler playerResourceHandler;
    [SerializeField] GameObject item;
    private SpriteRenderer spriteRenderer;
    private float value;
    private Item itemClass;

    private void Awake()
    {

        playerResourceHandler = player.GetComponent<PlayerResourceHandler>();
        spriteRenderer = item.GetComponent<SpriteRenderer>();
        value = 20f;
    }

    public Sprite getSprite()
    {

        return spriteRenderer.sprite;
    }

    public float getValue()
    {

        return value;
    }

    public string getName()
    {

        return item.name;
    }
}
