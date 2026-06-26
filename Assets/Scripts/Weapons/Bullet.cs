using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 3f;
    public float damage = 1;

    public int enemiesTouch = 0;
    public bool pierce = false;

    float lifeTimer;

    void OnEnable()
    {
        lifeTimer = lifeTime;
        enemiesTouch = 0;
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyBase enemy = other.GetComponent<EnemyBase>();

        if (enemy == null)
            return;

        enemy.TakeDamage(damage);

        enemiesTouch++;

        if (!pierce || enemiesTouch >= 2)
        {
            gameObject.SetActive(false);
        }
    }
}