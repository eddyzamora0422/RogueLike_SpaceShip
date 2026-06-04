using UnityEngine;

public class MissileBarrage : WeaponBase
{
    public GameObject missilePrefab;
    public Transform firePoint;

    public int missileCount = 6;

    protected override void Shoot()
    {
        for (int i = 0; i < missileCount; i++)
        {
            float angle = Random.Range(-25f, 25f);

            Quaternion rot = firePoint.rotation * Quaternion.Euler(0, 0, angle);

            Instantiate(missilePrefab, firePoint.position, rot);
        }
    }
}