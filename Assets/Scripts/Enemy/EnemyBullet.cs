using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 3f;
    public float damage = 1;
    float lifeTimer;

    void OnEnable()
    {
        lifeTimer = lifeTime;
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
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player == null)
            return;

        player.TakeDamage((int)damage);

     
        gameObject.SetActive(false);
       
    }
}
