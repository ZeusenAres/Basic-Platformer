using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScoreHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreUi;

    private int totalScore;

    public static CoinScoreHandler coinScoreHandler;

    void Awake()
    {

        coinScoreHandler = this;       
    }

    public void updateScoreDisplay(int points)
    {

        totalScore += points;

        scoreUi.text = totalScore.ToString();
    }
}
