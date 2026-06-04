using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public List<Transform> enemies = new List<Transform>();

    void Awake()
    {
        instance = this;
    }

    public void RegisterEnemy(Transform enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Transform enemy)
    {
        enemies.Remove(enemy);
    }
}