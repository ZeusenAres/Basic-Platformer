using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class TestTubeTrigger : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI output;
    [SerializeField] GameObject player;
    [SerializeField] Slider hungerBar;
    [SerializeField] Slider researchBar;
    private PlayerInventory inventory;
    private HungerBar hunger;
    private ResearchBar research;
    private bool isInputPromptOn;
    private string key;

    private void Start()
    {
        
        inventory = player.GetComponent<PlayerInventory>();
        hunger = hungerBar.GetComponent<HungerBar>();
        research = researchBar.GetComponent<ResearchBar>();
    }

    private void Update()
    {
        
        if (isInputPromptOn == true)
        {

            if (key == "F")
            {

                if (Input.GetKeyDown(KeyCode.F) == true)
                {

                    var items = inventory.getInventory();

                    foreach (var item in items.ToList())
                    {

                        if (item.name.StartsWith("Food"))
                        {

                            if (hungerBar.value == 100f || hungerBar.value == (100f - 5f))
                            {

                                break;
                            }
                            hunger.feed(item.value);
                            items.Remove(item);
                            continue;
                        }
                    }
                }
            }

            if (key == "R")
            {

                if (Input.GetKeyDown(KeyCode.R) == true)
                {

                    var items = inventory.getInventory();

                    foreach (var item in items.ToList())
                    {

                        if (item.name.StartsWith("Research"))
                        {

                            if (researchBar.value == 100f || researchBar.value == (100f - 5f))
                            {

                                break;
                            }
                            research.research(item.value);
                            items.Remove(item);
                            continue;
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
                isInputPromptOn = true;
            }

            if (gameObject.CompareTag("FoodTrigger"))
            {

                output.text = "F";
                key = output.text;
                isInputPromptOn = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            output.text = "";
            isInputPromptOn = false;
        }
    }
}
