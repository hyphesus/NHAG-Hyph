using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorManager animatorManager;
    AttackManager attackManager;
    PlayerLocomotion player1Locomotion;
    PlayerLocomotion player2Locomotion;
    Interactor interactor;
    GameObject player1;
    GameObject player2;

    public Vector2 p1MovementInput;
    public Vector2 p2MovementInput;
    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;
    //[HideInInspector] 
    [HideInInspector] public bool lightInput;
    [HideInInspector] public bool heavyInput;
    [HideInInspector] public bool pauseInput;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        attackManager = GetComponent<AttackManager>();
        interactor = GetComponent<Interactor>();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1Locomotion = player1.GetComponent<PlayerLocomotion>();
        if(player2 != null) { player2Locomotion = player2.GetComponent<PlayerLocomotion>(); }
    }
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.Player1.Movement.performed += i => p1MovementInput = i.ReadValue<Vector2>();
            playerControls.Player2.Movement.performed += i => p2MovementInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions1.LightAttack.performed += LightAttack;
            playerControls.PlayerActions1.HeavyAttack.performed += HeavyAttack;
            playerControls.PlayerActions1.Interact.performed += Interact;
            playerControls.PlayerActions2.LightAttack.performed += LightAttack;
            playerControls.PlayerActions2.HeavyAttack.performed += HeavyAttack;
            playerControls.PlayerActions2.Interact.performed += Interact;
        }

        playerControls.Enable();
    }
    private void Interact(InputAction.CallbackContext context)
    {
        interactor.Interact();
    }

    private void HeavyAttack(InputAction.CallbackContext context)
    {
        if (gameObject.tag == "Player1")
        {
            if (player1Locomotion)
            {
                {
                    if (player1Locomotion.isDashing)
                    {
                        Debug.Log("Heavy Dash Attack");
                    }
                    else
                    {
                        Debug.Log("Heavy Attack");
                    }
                }
            }

        }
    }

    private void LightAttack(InputAction.CallbackContext context)
    {
        if (context.action == playerControls.PlayerActions1.LightAttack)
            if (this.gameObject.tag == "Player1")
            {
                if (player1Locomotion)
                {
                    {
                        if (player1Locomotion.isDashing)
                        {
                            //dash light attack is the regular light attack for now
                            attackManager.ExecuteAttack();
                        }
                        else
                        {
                            attackManager.ExecuteAttack();
                        }
                    }
                }
            }
        if (context.action == playerControls.PlayerActions2.LightAttack)
            if (this.gameObject.tag == "Player2")
            {
                if (player2Locomotion)
                {
                    {
                        if (player2Locomotion.isDashing)
                        {
                            //dash light attack is the regular light attack for now
                            attackManager.ExecuteAttack();
                        }
                        else
                        {
                            attackManager.ExecuteAttack();
                        }
                    }
                }
            }
    }
    public IEnumerator SwitchLightBool()
    {
        yield return new WaitForEndOfFrame();
        lightInput = !lightInput;
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        if (this.gameObject.tag == "Player1")
            P1HandleMovementInput();
        if (this.gameObject.tag == "Player2")
            P2HandleMovementInput();
    }

    private void P1HandleMovementInput()
    {
        verticalInput = p1MovementInput.y;
        horizontalInput = p1MovementInput.x;
        // Debug.Log("\n" + "X: " + verticalInput + " Y: " + horizontalInput);
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }
    private void P2HandleMovementInput()
    {
        verticalInput = p2MovementInput.y;
        horizontalInput = p2MovementInput.x;
        // Debug.Log("\n" + "X: " + verticalInput + " Y: " + horizontalInput);
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }
}
