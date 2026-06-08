using UnityEngine;

public class MissileBarrage : WeaponBase
{
    public GameObject missilePrefab;
    public Transform firePoint;

    protected override void Shoot()
    {
        for (int i = 0; i < projectiles; i++)
        {
            float angle = Random.Range(-25f, 25f);

            Quaternion rot = firePoint.rotation * Quaternion.Euler(0, 0, angle);

            Instantiate(missilePrefab, firePoint.position, rot);
        }
    }
}