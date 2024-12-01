using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareLives : MonoBehaviour
// This script is supposed to be attached to an object with a trigger collider.
// The trigger volume is placed in the middle of the two players.
// The script finds the two players by their tags and then shares their health.
// When the trigger volume is entered by an object with the "LifeSharer" tag, the health of the two players is averaged and then set to that average.
{
    private GameObject player1;
    private GameObject player2;

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        if (player1 == null)
        {
            Debug.LogError("Player1 tag is not assigned to any GameObject in the scene.");
        }
        if (player2 == null)
        {
            Debug.LogError("Player2 tag is not assigned to any GameObject in the scene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Object to share hp with team
        if (other.CompareTag("LifeSharer"))
        {
            // Ensure both players exist
            if (player1 != null && player2 != null)
            {
                StatManager statManager1 = player1.GetComponent<StatManager>();
                StatManager statManager2 = player2.GetComponent<StatManager>();

                if (statManager1 != null && statManager2 != null)
                {
                    float health1 = statManager1.GetStat(StatManager.StatType.Health);
                    float health2 = statManager2.GetStat(StatManager.StatType.Health);
                    float averageHealth = (health1 + health2) / 2f;

                    // HP - (HP - Average HP) = Average HP
                    statManager1.LowerStat(StatManager.StatType.Health, health1 - averageHealth);
                    statManager2.LowerStat(StatManager.StatType.Health, health2 - averageHealth);
                }
                else
                {
                    Debug.LogError("StatManager component not found on one or both players.");
                }
            }
            else
            {
                Debug.LogError("Players not found.");
            }
        }
    }
}
