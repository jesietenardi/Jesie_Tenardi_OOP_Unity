using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Level;
    public EnemySpawner enemySpawner;

    public CombatManager combatManager;


    private void OnDestroy()
    {
        if (enemySpawner != null && combatManager != null)
        {
            enemySpawner.OnDeath();
            combatManager.RegisterKill(Level);
        }
    }
}
