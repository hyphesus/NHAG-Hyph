using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockManager : MonoBehaviour
{
    [SerializeField] CameraManager cameraManager;
    [HideInInspector] public int currentEnemies = 0;

    public void EnterLockedState()
    {
        if (cameraManager != null)
            cameraManager.cameraLocked = true;
    }
    public void EnemySlain()
    {
        currentEnemies--;
        CheckNumberOfEnemies();
    }
    public void CheckNumberOfEnemies()
    {
        if (currentEnemies <= 0)
        {
            cameraManager.cameraLocked = false;
            currentEnemies = 0;
        }
    }
}
