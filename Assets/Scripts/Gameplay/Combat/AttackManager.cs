using UnityEngine;


public class AttackManager : MonoBehaviour
{
    public MeleeAttack meleeAttack;
    public HeavyMeleeAttack heavyMeleeAttack;
    public RangedAttack rangedAttack;
    public SpecialAttack specialAttack;
    public TempAttack tempAttack;
    private TempWeaponChecker tempWeaponChecker;

    public bool isMeleeWeapon = true;
    public bool isRangedWeapon = false;

    private void Awake()
    {
        // Ensure references are set
        if (tempWeaponChecker == null)
            tempWeaponChecker = GetComponent<TempWeaponChecker>();

        if (meleeAttack == null)
            meleeAttack = GetComponent<MeleeAttack>();

        if (rangedAttack == null)
            rangedAttack = GetComponent<RangedAttack>();

        if (heavyMeleeAttack == null)
            heavyMeleeAttack = GetComponent<HeavyMeleeAttack>();

        if (specialAttack == null)
            specialAttack = GetComponent<SpecialAttack>();

        if (tempAttack == null)
            tempAttack = GetComponent<TempAttack>();
    }

    public void ExecuteAttack()
    {
        if (isMeleeWeapon && !tempWeaponChecker.tempWeapon)
        {
            meleeAttack.PerformMeleeAttack();
        }
        else if (isRangedWeapon && !tempWeaponChecker.tempWeapon)
        {
            rangedAttack.PerformRangedAttack();
        }
        else if (tempWeaponChecker.tempWeapon)
        {
            tempAttack.PerformTempAttack();
        }
        else
        {
            Debug.LogWarning("No valid attack type found!");
        }
    }
    public void ExecuteHeavyAttack()
    {
        if (isMeleeWeapon && !tempWeaponChecker.tempWeapon)
        {
            heavyMeleeAttack.PerformHeavyMeleeAttack();
        }
        // else if (isRangedWeapon && !tempWeaponChecker.tempWeapon)
        // {
        //     heavyRangedAttack.PerformHeavyRangedAttack(); // unlock this section for ranged heavy attack when implemented
        // }
        else if (tempWeaponChecker.tempWeapon)
        {
            tempAttack.PerformHeavyTempAttack();
        }
        else
        {
            Debug.LogWarning("No valid heavy attack type found!");
        }
    }
    public void ExecuteSpecialAttack()
    {
        if (isMeleeWeapon && !tempWeaponChecker.tempWeapon)
        {
            specialAttack.PerformSpecialAttack();
        }
        // else if (isRangedWeapon && !tempWeaponChecker.tempWeapon)
        // {
        //     specialRangedAttack.PerformSpecialRangedAttack(); // unlock this section for ranged special attack when implemented
        // }
        // else if (tempWeaponChecker.tempWeapon)
        // {
        //     // Handle temporary weapon attack, if applicable
        //     // For example, you could have a special attack script for this
        // }
        else
        {
            Debug.LogWarning("No valid special attack type found!");
        }
    }
}
