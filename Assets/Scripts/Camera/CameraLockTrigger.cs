using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockTrigger : MonoBehaviour
{
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] CameraLockManager cameraLockManager;
    bool enemiesSpawned = false;
    private void OnTriggerEnter(Collider collider)
    {
        if (!enemiesSpawned)
        {
            if (collider.tag == "Player1" || collider.tag == "Player2")
            {
                cameraLockManager.EnterLockedState();
                enemiesSpawned = true;
                cameraLockManager.currentEnemies = enemySpawner.numberOfEnemiesToSpawn;
                StartCoroutine(enemySpawner.SpawnEnemy());
            }
        }
    }
}
