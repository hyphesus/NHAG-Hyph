using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public int numberOfEnemiesToSpawn;
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] public CameraLockManager cameraLockManager;
    [SerializeField] bool spawnImmediately;

    private void Start()
    {
        if (spawnImmediately)
            SpawnEnemy();
    }
    public IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            GameObject tempEnemy = Instantiate(enemyToSpawn, this.transform.position, Quaternion.identity);
            EnemyBehavior enemyBehavior = tempEnemy.GetComponent<EnemyBehavior>();
            yield return new WaitForEndOfFrame();
            enemyBehavior.SetEnemySpawner(this);
        }
    }
}
