using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Stats")]
    public float health = 3;
    public float speed = 2f;
    public float damage = 1f;

    [Header("Loot")]
    public GameObject xpPrefab;
    public GameObject coinPrefab;

    bool dead = false;
    protected Transform player;

    protected virtual void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;   
        EnemyManager.instance.RegisterEnemy(transform);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (player == null)
            return;

        Move();
    }

    protected abstract void Move();

    public void TakeDamage(float dmg)
    {
        print("el enemigo si recibio daño");
        health -= dmg;

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (dead) return;
        dead = true;
        EnemyManager.instance.RemoveEnemy(transform);
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        Instantiate(xpPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage((int)damage);
            Destroy(gameObject);
        }
    }
}
