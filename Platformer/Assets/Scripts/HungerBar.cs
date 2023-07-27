using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{

    [SerializeField] Slider hungerBar;
    private float currentAmount;
    private float maxAmount = 100;

    void Start()
    {

        hungerBar.maxValue = maxAmount;
        currentAmount = maxAmount;
        hungerBar.value = currentAmount;
    }

    private void Update()
    {

        //StartCoroutine(wait());
        currentAmount -= 0.005f;
        hungerBar.value = currentAmount;
        //Debug.Log(hungerBar.value);
    }

    public float feed(float value)
    {

        return currentAmount += value;
    }
}
