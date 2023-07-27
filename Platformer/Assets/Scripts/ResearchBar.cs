using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchBar : MonoBehaviour
{

    [SerializeField] Slider researchBar;
    private float currentAmount;
    //private float maxAmount = 100;

    void Start()
    {

        currentAmount = 0f;
        researchBar.maxValue = 100f;
    }

    private void Update()
    {
        
        researchBar.value = currentAmount;
    }

    public float research(float value)
    {

        return currentAmount += value;
    }
}
