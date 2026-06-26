using UnityEngine;

public class MachineGun : WeaponBase
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float spreadAngle = 3f;

    //TurretRecoil recoil;

    public float projectileSpacing = 0.2f;

    void Start()
    {
        //recoil = GetComponent<TurretRecoil>();
    }

    void Awake()
    {
        weaponType = WeaponType.MachineGun;
    }

    protected override void Shoot()
    {
        float angle = Random.Range(-spreadAngle, spreadAngle);

        Quaternion spreadRotation =
            firePoint.rotation * Quaternion.Euler(0, 0, angle);

        for (int i = 0; i < projectiles; i++)
        {
            Vector3 offset = firePoint.right * ((i - (projectiles - 1) / 2f) * projectileSpacing);

            GameObject bullet = BulletPool.instance.GetBullet();

            bullet.transform.position = firePoint.position + offset;
            bullet.transform.rotation = spreadRotation;

            Bullet b = bullet.GetComponent<Bullet>();
            b.damage = damage;
        }
        //recoil.ApplyRecoil();   
    }
}