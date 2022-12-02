using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] int points;

    public int getPoints()
    {

        return points;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }
}
