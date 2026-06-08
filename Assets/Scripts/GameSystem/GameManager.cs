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
    public GameObject pauseMenu;

    public static bool isPaused = false;    //Flag pause
    public static bool isUpgradePanel = false;  //Flag upgradePanel

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ShowUpgradeScreen();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
                isPaused = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                isPaused = true;
            }
        }

        if (upgradePanel.activeInHierarchy)
        {
            isPaused = true;
        }

        isRun(isPaused);
        
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
        isPaused = true;

        upgradePanel.SetActive(true);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        List<Upgrade> upgrades = UpgradeManager.instance.GetRandomUpgrades(player, 3);

        UpgradeUI.instance.Show(upgrades);
    }

    void isRun(bool request)
    {
        if (request) 
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }
}