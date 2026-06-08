using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public float fireRate = 0.2f;
    protected float lastShot;

    public WeaponType weaponType;

    public float damage = 1;

    public int projectiles = 1;

    protected float fireTimer;

    public virtual void TryShoot()
    {
        //Verifica la bandera de pausa antes de disparar. GameManager is paused.
        if (GameManager.isPaused) return; 
   
        if (Time.time >= lastShot + fireRate)
        {
            Shoot();
            lastShot = Time.time;
        }
    }

    protected abstract void Shoot();

    protected virtual void Update()
    {
        fireTimer -= Time.deltaTime;
    }
}
