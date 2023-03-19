using PlayerController;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public float Money;

    public void PuttingMoneyInMachine(float money)
    {
        Money += money;
        GetComponentInChildren<Display>().UpdateMoneyInVendingMachine(Money.ToString("F2"));
        FindObjectOfType<CameraController>().Money -= money;
    }
    public void WithdrowMoneyFromMachine()
    {
        FindObjectOfType<CameraController>().Money += Money;
        Money = 0;
        GetComponentInChildren<Display>().UpdateMoneyInVendingMachine(Money.ToString("F2"));
    }

  
}
