using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowAI : MonoBehaviour
{
    Rigidbody enemyRB;
    GameObject objectToFollow;
    [SerializeField] float enemySpeed;
    Vector3 storedPosition;
    Vector3 velocity = Vector3.zero;
    EnemyBehavior enemyBehavior;
    NavMeshAgent agent;


    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        enemyBehavior = GetComponent<EnemyBehavior>();
        //TODO: Determine which player is closer, then follow them
        objectToFollow = enemyBehavior.player1;
        if (objectToFollow == null)
        {
            Debug.LogError("No player to follow");
        }
        storedPosition = transform.position;
    }

    private void Update()
    {
        if (objectToFollow != null)
        {
            if (enemyBehavior.isHit != true)
            {
                if (!TooClose())
                {
                    //move the enemy towards the object
                    agent.destination = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y + 1, objectToFollow.transform.position.z);
                    enemyRB.velocity = Vector3.zero;
                }
                else
                    agent.destination = this.transform.position;
                //have the enemy constantly face the object
                this.transform.LookAt(new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y + 1, objectToFollow.transform.position.z));
            }
            else
                agent.destination = this.transform.position;
        }
    }
    //checks if the enemy is too close to the target
    bool TooClose()
    {
        if (Mathf.Abs(objectToFollow.transform.position.x - this.transform.position.x) < 1.5f && Mathf.Abs(objectToFollow.transform.position.z - this.transform.position.z) < 1.5f)
            return true;
        return false;
    }
}