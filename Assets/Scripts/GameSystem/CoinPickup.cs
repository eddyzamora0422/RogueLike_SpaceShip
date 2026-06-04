using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddCoins(value);
            Destroy(gameObject);
        }
    }
}