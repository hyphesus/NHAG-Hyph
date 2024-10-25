using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnemyFilter : MonoBehaviour
{
    //This script lets the enemy walk through the camera "walls"
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), collision.collider);
        }
    }
}
