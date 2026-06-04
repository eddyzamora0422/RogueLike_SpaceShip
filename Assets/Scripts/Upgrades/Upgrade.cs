using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/New Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public string description;

    public UpgradeType type;
    public UpgradeRarity rarity;

    public WeaponType targetWeapon;

    public float damageMultiplier = 1f;
    public float fireRateMultiplier = 1f;
    public int addProjectiles = 0;

    public void ApplyUpgrade(GameObject player)
    {
        WeaponBase[] weapons = player.GetComponentsInChildren<WeaponBase>();

        foreach (WeaponBase weapon in weapons)
        {
            if (weapon.weaponType == targetWeapon)
            {
                weapon.damage *= damageMultiplier;
                weapon.fireRate *= fireRateMultiplier;
                weapon.projectiles += addProjectiles;
            }
        }
    }
}
