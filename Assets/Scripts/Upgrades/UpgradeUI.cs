using UnityEngine;
using System.Collections.Generic;

public class UpgradeUI : MonoBehaviour
{
    public static UpgradeUI instance;

    public UpgradeButton[] buttons;

    void Awake()
    {
        instance = this;
    }

    public void Show(List<Upgrade> upgrades)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < upgrades.Count)
            {
                buttons[i].gameObject.SetActive(true);
                buttons[i].Setup(upgrades[i]);
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }

}
