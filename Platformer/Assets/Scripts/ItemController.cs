using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject item;
    private SpriteRenderer spriteRenderer;
    private float value;

    private void Awake()
    {

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }
}
