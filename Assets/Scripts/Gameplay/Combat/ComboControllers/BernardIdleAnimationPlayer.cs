using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BernardIdleAnimationPlayer : MonoBehaviour
{
    public Animator bernardAnimator;
    public PlayerLocomotion playerLocomotion;
    public float idleDelay = 10f;
    private float inactivityTimer = 0f;
    private bool idleTriggered = false;

    private void Update()
    {
        // Ensure references are assigned
        if (bernardAnimator == null)
        {
            Debug.LogWarning("Animator is not assigned in the Inspector.");
            return;
        }

        if (playerLocomotion == null)
        {
            Debug.LogWarning("PlayerLocomotion script is not assigned in the Inspector.");
            return;
        }

        if (!playerLocomotion.isRunning && !playerLocomotion.isDashing)
        {
            inactivityTimer += Time.deltaTime;

            if (inactivityTimer >= idleDelay && !idleTriggered)
            {
                bernardAnimator.SetTrigger("bernardIdle");
                idleTriggered = true;
            }
        }
        else
        {
            // Reset the inactivity timer and flag
            inactivityTimer = 0f;
            idleTriggered = false;
        }
    }
}