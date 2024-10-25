using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetTransform; //The object the camera will follow
    private Vector3 cameraFollowVelocity = Vector3.zero;
    [HideInInspector] public bool cameraLocked = false;
    GameObject player1;
    GameObject player2;

    public float cameraFollowSpeed = 0.2f;
    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        FindTarget();
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        for (int i = 0; i < 6; i++)
        {
            GameObject p = GameObject.CreatePrimitive(PrimitiveType.Plane);
            p.transform.parent = this.transform;
            p.transform.localScale = p.transform.localScale * 2;
            p.AddComponent<CameraEnemyFilter>();
            p.name = "Plane" + i.ToString();
            p.transform.position = -planes[i].normal * planes[i].distance;
            p.transform.rotation = Quaternion.FromToRotation(Vector3.up, planes[i].normal);
            BoxCollider box = p.AddComponent<BoxCollider>();
        }
    }
    private void Update()
    {
        FindTarget();
    }
    public void FindTarget()
    {
        if (player2 != null)
        {
            {
                float delta = player1.transform.position.x - player2.transform.position.x;
                if (delta > 0)
                    targetTransform = player1.transform;
                else
                    targetTransform = player2.transform;
            }
        }
        else
            targetTransform = player1.transform;
    }
    public void FollowTarget()
    {
        if (!cameraLocked)
        {
            Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
            targetPosition.z = 0;
            transform.position = targetPosition;
        }
        //maybe have it snap to desired position
        //else
    }
}
