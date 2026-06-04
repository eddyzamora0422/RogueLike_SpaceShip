using UnityEngine;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public List<Upgrade> allUpgrades = new List<Upgrade>();

    void Awake()
    {
        instance = this;
    }

    public List<Upgrade> GetAvailableUpgrades(GameObject player)
    {
        List<Upgrade> validUpgrades = new List<Upgrade>();

        WeaponBase[] weapons = player.GetComponentsInChildren<WeaponBase>();

        foreach (Upgrade upgrade in allUpgrades)
        {
            if (upgrade.type == UpgradeType.Player)
            {
                validUpgrades.Add(upgrade);
                continue;
            }

            foreach (WeaponBase weapon in weapons)
            {
                if (weapon.weaponType == upgrade.targetWeapon)
                {
                    validUpgrades.Add(upgrade);
                    break;
                }
            }
        }

        return validUpgrades;
    }

    public List<Upgrade> GetRandomUpgrades(GameObject player, int count)
    {
        List<Upgrade> validUpgrades = GetAvailableUpgrades(player);

        List<Upgrade> result = new List<Upgrade>();

        for (int i = 0; i < count; i++)
        {
            if (validUpgrades.Count == 0)
                break;

            int index = Random.Range(0, validUpgrades.Count);

            Upgrade randomUpgrade = validUpgrades[index];

            result.Add(randomUpgrade);

            validUpgrades.RemoveAt(index);
        }

        return result;
    }


}
