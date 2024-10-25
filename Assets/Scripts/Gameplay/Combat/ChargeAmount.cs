using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAmount : MonoBehaviour
{
    public int chargeAmount = 0;
    public int maxChargeAmount = 100;
    public int decreaseAmount = 5;

    public void AddCharge(int amount)
    {
        chargeAmount += amount;
        if (chargeAmount > maxChargeAmount)
        {
            chargeAmount = maxChargeAmount;
        }
    }

    public void DecreaseCharge()
    {
        chargeAmount -= decreaseAmount;
        if (chargeAmount < 0)
        {
            chargeAmount = 0;
        }
    }
}
