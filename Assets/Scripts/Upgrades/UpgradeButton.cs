using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Text title;
    public Text description;

    Upgrade currentUpgrade;

    public void Setup(Upgrade upgrade)
    {
        currentUpgrade = upgrade;

        title.text = upgrade.upgradeName;
        description.text = upgrade.description;
    }

    public void OnClick()
    {
        currentUpgrade.ApplyUpgrade(GameObject.FindGameObjectWithTag("Player"));

        Time.timeScale = 1;

        GameManager.instance.upgradePanel.SetActive(false);
    }
}