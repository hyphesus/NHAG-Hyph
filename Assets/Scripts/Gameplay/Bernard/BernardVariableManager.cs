using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BernardVariableManager : MonoBehaviour
{
    public GameObject PlayerLocomotion;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool("isRunning", PlayerLocomotion.GetComponent<PlayerLocomotion>().isRunning);
        animator.SetBool("isDashing", PlayerLocomotion.GetComponent<PlayerLocomotion>().isDashing);
    }
}
