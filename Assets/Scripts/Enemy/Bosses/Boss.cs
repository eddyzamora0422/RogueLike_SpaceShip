using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Boss : WeaponBase
{
    //public int bossHealth = 100;
    public float speed = 2f;
    public float stoppingDistance = 50;
    public Transform firePoint;
    public float spreadAngle = 3f;
    public float projectileSpacing = 0.2f;

    public static bool bossIsAlive = false;

    Transform player;
    
    void Start()
    {
        bossIsAlive = true;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");

            if (p != null)
                player = p.transform;

        }
    }

    void Update()
    {
        if (player == null)
            return;

        Vector2 direction = player.position - transform.position;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stoppingDistance)
        {
            float speedMultiplier = Mathf.Clamp01((distance - stoppingDistance) / 2f);
            transform.position += (Vector3)direction.normalized * speed * speedMultiplier * Time.deltaTime;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        TryShoot();
    }

    protected override void Shoot()
    {
        float angle = Random.Range(-spreadAngle, spreadAngle);

        Quaternion spreadRotation =
            firePoint.rotation * Quaternion.Euler(0, 0, angle);

        for (int i = 0; i < projectiles; i++)
        {
            Vector3 offset = firePoint.right * ((i - (projectiles - 1) / 2f) * projectileSpacing);

            GameObject bullet = BulletPoolEnemy.instance.GetBullet();

            bullet.transform.position = firePoint.position + offset;
            bullet.transform.rotation = spreadRotation;

            EnemyBullet b = bullet.GetComponent<EnemyBullet>();
            b.damage = damage;
            //Bullet.isEnemyBullet = true;
            bullet.SetActive(true);
        }
    }


}
