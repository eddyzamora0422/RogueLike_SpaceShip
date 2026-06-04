using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public WeaponBase primaryWeapon;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            primaryWeapon.TryShoot();
        }
    }
}
