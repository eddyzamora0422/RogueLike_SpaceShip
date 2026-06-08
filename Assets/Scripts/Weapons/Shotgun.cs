using UnityEngine;

public class Shotgun : WeaponBase
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    //public int pelletCount;      // cuántas balas dispara
    public float spreadAngle = 30f;  // apertura del disparo

    TurretRecoil recoil;

    private void Start()
    {
        recoil = GetComponent<TurretRecoil>();
    }


    protected override void Shoot()
    {
        float angleStep = spreadAngle / (projectiles - 1);
        float startAngle = -spreadAngle / 2;
        //pelletCount = projectiles;

        for (int i = 0; i < projectiles; i++)
        {
            float angle = startAngle + (angleStep * i);

            Quaternion rotation = firePoint.rotation * Quaternion.Euler(0, 0, angle);

            Instantiate(bulletPrefab, firePoint.position, rotation);
        }
        recoil.ApplyRecoil();
    }
}