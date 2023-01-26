using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinScoreHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreUi;
    [SerializeField] TextMeshProUGUI silverPlackUi;
    [SerializeField] Image collectibleIcon;
    [SerializeField] TextMeshProUGUI weightDisplay;
    private Int16 totalScore;
    private Int16 totalSilverPlackScore;
    private string weight;
    private Color textColor;
    public static CoinScoreHandler coinScoreHandler;

    void Awake()
    {

        coinScoreHandler = this;

        weightDisplay.text = string.Empty;
    }

    public string setWeight(string weight)
    {

        weightDisplay.text = weight;


        return this.weight = weight;
    }

    public Color setTextColor(Color color)
    {

        return textColor = color;
    }

    public void updateScoreDisplay(Int16 amount, Int16 points, Sprite sprite, string weight, Color color)
    {

        if (Int16.Parse(weight) < 24)
        {

            Color newColor = this.setTextColor(Color.green);

            weightDisplay.color = newColor;
        }

        if (Int16.Parse(weight) >= 24)
        {

            Color newColor = this.setTextColor(Color.red);

            weightDisplay.color = newColor;
        }

        totalSilverPlackScore += points;

        silverPlackUi.text = totalSilverPlackScore.ToString();

        totalScore += amount;

        scoreUi.text = totalScore.ToString();

        collectibleIcon.sprite = sprite;

        collectibleIcon.color = color;

        Image icon = Instantiate(
            collectibleIcon,
            new Vector3(0, 0, 0),
            Quaternion.identity
        );

        icon.transform.SetParent(GameObject.FindGameObjectWithTag("CollectibleDisplay").transform, false);

        TextMeshProUGUI coinWeight = Instantiate(
            weightDisplay,
            new Vector3(0, 0, 0),
            Quaternion.identity
        );

        weightDisplay.text = weight;

        coinWeight.transform.SetParent(icon.transform, false);
    }
}
