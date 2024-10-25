using UnityEngine;
using System.Collections;


public class TempWeaponChecker : MonoBehaviour
{
    public bool tempWeapon { get; private set; } = false;
    [SerializeField] private float tempWeaponCooldown = 2f;

    private void OnTriggerEnter(Collider other)
    {
        //Assign the tag for temporary weapons in scene and give them collider (is check=true)
        if (other.CompareTag("TemporaryWeapon"))
        {
            tempWeapon = true;
            Debug.Log("Temporary Weapon Acquired!");
            StartCoroutine(ResetTempWeaponAfterCooldown());
        }
        else
        {
            Debug.Log("Trigger is not a Temporary Weapon Tagged item!");
        }
    }

    private IEnumerator ResetTempWeaponAfterCooldown()
    {
        yield return new WaitForSeconds(tempWeaponCooldown);
        tempWeapon = false;
        Debug.Log("Temporary Weapon Expired!");
    }
}
