using UnityEngine;

public class PamelaComboController : MonoBehaviour
{
    public Animator pamelaAnimator; // Assign Pamela Combo Animator
    public float comboWindow = 1f;
    private float comboTimer = 0f;
    private int comboIndex = 0;
    private bool isAttacking = false;
    private string comboType = "";

    private InputManager inputManager; //Assign InputManager

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        // Combo window timer
        if (isAttacking)
        {
            comboTimer += Time.deltaTime;

            if (comboTimer > comboWindow)
            {
                ResetCombo();
            }
        }
        HandleComboInputs();
    }
    private void HandleComboInputs()
    {
        if (inputManager.lightInput && !isAttacking)
        {
            StartLightCombo();
        }
        else if (inputManager.lightInput && isAttacking && comboType == "light")
        {
            ContinueLightCombo();
            OnAttackFinished();
        }

        if (inputManager.heavyInput && !isAttacking)
        {
            StartHeavyCombo();
        }
        else if (inputManager.heavyInput && isAttacking && comboType == "heavy")
        {
            ContinueHeavyCombo();
            OnAttackFinished();
        }
    }
    private void StartLightCombo()
    {
        comboIndex = 1;
        comboType = "light";
        isAttacking = true;
        comboTimer = 0f;
        pamelaAnimator.SetTrigger("pamelaLightTrigger");
    }
    private void ContinueLightCombo()
    {
        if (comboIndex < 3)
        {
            comboIndex++;
            comboTimer = 0f;
            pamelaAnimator.SetTrigger("pamelaLightTrigger");
        }
        else
        {
            ResetCombo();
        }
    }
    private void StartHeavyCombo()
    {
        comboIndex = 1;
        comboType = "heavy";
        isAttacking = true;
        comboTimer = 0f;
        pamelaAnimator.SetTrigger("pamelaHeavyTrigger");
    }
    private void ContinueHeavyCombo()
    {
        if (comboIndex < 3)
        {
            comboIndex++;
            comboTimer = 0f;
            pamelaAnimator.SetTrigger("pamelaHeavyTrigger");
        }
        else
        {
            ResetCombo();
        }
    }
    private void ResetCombo()
    {
        comboIndex = 0;
        comboType = "";
        isAttacking = false;
        comboTimer = 0f;
        pamelaAnimator.SetTrigger("pamelaResetTrigger");  // reset to idle or neutral state

    }
    public void OnAttackFinished()
    {
        if (comboIndex == 3 && comboType == "light")
        {
            ResetCombo();
        }
        else if (comboIndex == 3 && comboType == "heavy")
        {
            ResetCombo();
        }
    }
}
