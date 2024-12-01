using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    StatManager statManager;
    //temp code to test implementation
    private void Start()
    {
        statManager = GetComponent<StatManager>();
        GetComponent<StatManager>().AddCallBack(StatManager.StatType.Health, CheckIfDead);
    }
    void CheckIfDead(StatManager.StatType type, float aValue)
    {
        if (aValue <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                //tell the spawner that the enemy died
                EnemyBehavior enemyBehavior = GetComponent<EnemyBehavior>();
                enemyBehavior.Die();
                return;
            }
            if(gameObject.tag == "Table")
            {
                //eventually make a script that shatters the table5
                Destroy(gameObject);
            }
            //Player died, game over 
        }
    }
}
