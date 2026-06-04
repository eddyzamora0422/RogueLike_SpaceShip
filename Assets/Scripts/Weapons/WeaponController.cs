using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponBase primaryWeapon;
    public WeaponBase secondaryWeapon;
    public WeaponBase specialWeapon;

    void Update()
    {
        bool left = Input.GetMouseButton(0);
        bool right = Input.GetMouseButton(1);

        // arma especial
        if (left && right)
        {
            if (specialWeapon != null)
                specialWeapon.TryShoot();

            return;
        }

        // primaria
        if (left)
        {
            if (primaryWeapon != null)
                primaryWeapon.TryShoot();
        }

        // secundaria
        if (right)
        {
            if (secondaryWeapon != null)
                secondaryWeapon.TryShoot();
        }
    }
}