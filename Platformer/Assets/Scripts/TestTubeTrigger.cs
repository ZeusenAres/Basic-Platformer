using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class TestTubeTrigger : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI output;
    [SerializeField] GameObject player;
    [SerializeField] GameObject hungerBar;
    [SerializeField] GameObject researchBar;
    private PlayerInventory inventory;
    private List<Item> items;
    private HungerBar hunger;
    private ResearchBar research;
    private bool isInputpromptOn;
    private string key;

    private void Start()
    {
        
        inventory = player.GetComponent<PlayerInventory>();
        items = inventory.getInventory();
        hunger = hungerBar.GetComponent<HungerBar>();
        research = researchBar.GetComponent<ResearchBar>();
    }

    private void Update()
    {
        
        if (isInputpromptOn == true)
        {

            if (key == "F")
            {
                if (Input.GetKeyDown(KeyCode.F) == true)
                {

                    foreach (var item in items)
                    {

                        if (item.name.StartsWith("Food"))
                        {

                            hunger.feed(item.value);
                        }

                        if (!item.name.StartsWith("Research"))
                        {

                            Debug.Log("Insufficient resources");
                            return;
                        }
                    }
                }
            }

            if (key == "R")
            {

                if (Input.GetKeyDown(KeyCode.R) == true)
                {

                    foreach (var item in items)
                    {

                        if (item.name.StartsWith("Research"))
                        {

                            research.research(item.value);
                        }

                        if (!item.name.StartsWith("Research"))
                        {

                            Debug.Log("Insufficient resources");
                            return;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            if (gameObject.CompareTag("ResearchTrigger"))
            {

                output.text = "R";
                key = output.text;
                isInputpromptOn = true;
                //alphaValue = (int)Enum.Parse(typeof(KeyCode), output.text);
            }

            if (gameObject.CompareTag("FoodTrigger"))
            {

                output.text = "F";
                key = output.text;
                isInputpromptOn = true;
                //alphaValue = (int)Enum.Parse(typeof(KeyCode), output.text);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            output.text = "";
            isInputpromptOn = false;
        }
    }
}
