using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public float health = 3;

    public GameObject xpPrefab;

    public GameObject coinPrefab;

    bool dead = false;

    void Start()
    {
        EnemyManager.instance.RegisterEnemy(transform);
    }

    public void TakeDamage(float damage)
    {
        print("el enemigo si recibio daño");
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (dead) return;
        dead = true;

        EnemyManager.instance.RemoveEnemy(transform);
        
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        Instantiate(xpPrefab, transform.position, Quaternion.identity);

        if (Boss.bossIsAlive)
        {
            Boss.bossIsAlive = false;
            GameManager.isVictory = true;
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}