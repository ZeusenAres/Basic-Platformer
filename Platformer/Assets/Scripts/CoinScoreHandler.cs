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
    private int totalScore;
    private int totalSilverPlackScore;
    public static CoinScoreHandler coinScoreHandler;

    void Awake()
    {

        coinScoreHandler = this;
    }

    public void updateScoreDisplay(int amount, int points)
    {

        totalSilverPlackScore += points;

        totalScore += amount;

        silverPlackUi.text = totalSilverPlackScore.ToString();

        scoreUi.text = totalScore.ToString();
    }

    public void addToCoinDisplay(Sprite sprite, Int16 weight, Color color)
    {

        collectibleIcon.sprite = sprite;

        weightDisplay.text = weight.ToString();

        collectibleIcon.color = color;

        Image icon = Instantiate(
            collectibleIcon,
            new Vector3(0, 0, 0),
            Quaternion.identity
        );

        icon.transform.SetParent(GameObject.FindGameObjectWithTag("CollectibleDisplay").transform, false);
    }
}
