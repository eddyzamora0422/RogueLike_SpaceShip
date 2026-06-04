using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int currentXP = 0;
    public int level = 1;
    public int xpToNextLevel = 5;

    public void AddXP(int amount)
    {
        currentXP += amount;

        Debug.Log("XP: " + currentXP);

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        currentXP = 0;
        xpToNextLevel += 5;

        Debug.Log("LEVEL UP! Nivel actual: " + level);
    }
}