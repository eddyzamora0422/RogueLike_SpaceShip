using System.Collections.Generic;
using UnityEngine;

public class BulletPoolEnemy : MonoBehaviour
{
    public static BulletPoolEnemy instance;

    public GameObject bulletPrefab;
    public int poolSize = 100;

    List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pool.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in pool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(bulletPrefab);
        pool.Add(newBullet);
        return newBullet;
    }
}
