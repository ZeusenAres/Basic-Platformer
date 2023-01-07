using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScoreHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreUi;
    [SerializeField] TextMeshProUGUI silverPlackUi;
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
}
