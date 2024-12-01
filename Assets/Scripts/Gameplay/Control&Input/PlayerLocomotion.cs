using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidBody;

    float minSpeed = 4;
    float maxSpeed = 7;
    float movementSpeed;
    float rotationSpeed = 15;
    public bool isRunning;
    public bool isDashing;
    float sprintTimer = 1;
    bool vSprintCheck;
    bool hSprintCheck;
    float lastVerticalValue = 1;
    float lastHorizontalValue = 1;
    [HideInInspector] public bool isPunching;
    GameObject Player1;
    GameObject Player2;


    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
        Player1 = GameObject.FindGameObjectWithTag("Player1");
    }
    private void Update()
    {
        //dashing checks
        if (inputManager.moveAmount > 0)
        {
            isRunning = true;
            if (vSprintCheck && hSprintCheck)
            {
                if (sprintTimer <= 0)
                {
                    movementSpeed = maxSpeed;
                    isDashing = true;
                }
                else
                {
                    sprintTimer -= Time.deltaTime;
                }
            }
            else
            {
                sprintTimer = 1;
                movementSpeed = minSpeed;
                isDashing = false;
            }
        }
        else
        {
            sprintTimer = 1;
            isRunning = false;
            isDashing = false;
            movementSpeed = minSpeed;
        }
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement()
    {
        if (!isPunching)
        {
            //sprintCheck logic
            if (inputManager.moveAmount > 0)
            {
                if (inputManager.verticalInput == lastVerticalValue)
                    vSprintCheck = true;
                else
                    vSprintCheck = false; lastVerticalValue = inputManager.verticalInput;
                if (inputManager.horizontalInput == lastHorizontalValue)
                    hSprintCheck = true;
                else
                    hSprintCheck = false; lastHorizontalValue = inputManager.horizontalInput;
            }
            moveDirection = cameraObject.forward * inputManager.verticalInput;
            moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
            moveDirection.Normalize();
            moveDirection.y = (float)(-9.81 * 2 * Time.deltaTime);
            moveDirection = moveDirection * movementSpeed;

            Vector3 movementVelocity = moveDirection;
            playerRigidBody.velocity = movementVelocity;
        }
    }
    private void HandleRotation()
    {
        if (!isPunching)
        {
            Vector3 targetDirection = Vector3.zero;

            targetDirection = cameraObject.forward * inputManager.verticalInput;
            targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
            targetDirection.Normalize();
            targetDirection.y = 0;

            if (targetDirection == Vector3.zero)
            {
                targetDirection = transform.forward;
            }
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = playerRotation;
        }
    }
}
