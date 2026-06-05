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
        //FindObjectOfType<CameraShake>().Shake(0.5f, 1f);

        /*
        Instantiate(xpPrefab, (Vector2)transform.position + Random.insideUnitCircle * 0.5f, Quaternion.identity);

        Vector2 offset = Random.insideUnitCircle * 0.5f;

        Instantiate(coinPrefab, (Vector2)transform.position + offset, Quaternion.identity);*/

        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        Instantiate(xpPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(10);
            Destroy(gameObject);

        }
    }
}