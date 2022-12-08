using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{

    private int points = 1;

    private int totalScore;

    [SerializeField] TextMeshProUGUI scoreHud;

    private void Start()
    {
        
        scoreHud = GetComponent<TextMeshProUGUI>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {

            totalScore += points;

            string scoreUi = totalScore.ToString();

            scoreHud.text = scoreUi;

            Destroy(gameObject);
        }
    }
}
