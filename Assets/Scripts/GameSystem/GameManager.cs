using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int coins;

    public int level = 1;
    public float xp = 0;
    public float xpToNextLevel = 10;

    public GameObject player;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ShowUpgradeScreen();
        }
    }
    void Awake()
    {
        instance = this;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
    }

    public void AddXP(float amount)
    {
        xp += amount;

        if (xp >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        xp -= xpToNextLevel;
        level++;

        xpToNextLevel *= 1.3f;

        Debug.Log("LEVEL UP: " + level);

        // aquí luego abriremos la pantalla de mejoras

        ShowUpgradeScreen();

    }

    public GameObject upgradePanel;

    void ShowUpgradeScreen()
    {
        Time.timeScale = 0;

        upgradePanel.SetActive(true);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        List<Upgrade> upgrades = UpgradeManager.instance.GetRandomUpgrades(player, 3);

        UpgradeUI.instance.Show(upgrades);
    }
}