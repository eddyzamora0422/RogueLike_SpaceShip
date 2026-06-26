using UnityEngine;

public class DroneGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 1f;
    float lastShot;

    public float detectionRange = 10f;

    void Update()
    {
        if (Time.time >= lastShot + fireRate)
        {
            Transform target = FindClosestEnemy();

            if (target != null)
            {
                Shoot(target);
                lastShot = Time.time;
            }
        }
    }

    Transform FindClosestEnemy()
    {
        Transform closest = null;
        float minDistance = Mathf.Infinity;

        foreach (Transform enemy in EnemyManager.instance.enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }

    void Shoot(Transform target)
    {
        Vector2 direction = target.position - firePoint.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        Instantiate(bulletPrefab, firePoint.position, rotation);
    }
}
