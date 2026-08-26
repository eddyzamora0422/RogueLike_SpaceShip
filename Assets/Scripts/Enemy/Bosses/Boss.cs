using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Boss : EnemyBase
{
    public float stoppingDistance = 50;
    public Transform firePoint;
    public float spreadAngle = 3f;
    public float projectileSpacing = 0.2f;

    public static bool bossIsAlive = false;


    [Header("WeaponAtributes")]
    public float fireRate = 0.2f;
    protected float lastShot;
    public WeaponType weaponType;
    public float damageBullet = 1;
    public int projectiles = 1;
    protected float fireTimer;
    
    protected override void Start()
    {
        base.Start();
        bossIsAlive = true;
    }
   
    public void Shoot()
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
            b.damage = damageBullet;
            //Bullet.isEnemyBullet = true;
            bullet.SetActive(true);
        }
    }

    private void TryShoot()
    {
        //Verifica la bandera de pausa antes de disparar. GameManager is paused.
        if (GameManager.isPaused) return;

        if (Time.time >= lastShot + fireRate)
        {
            Shoot();
            lastShot = Time.time;
        }
    }

    protected override void Move()
    {
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

    protected override void Die()
    {
        base.Die();
        Boss.bossIsAlive = false;
        GameManager.isVictory = true;
    }
}
