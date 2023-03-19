using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    public TextMeshPro DisplayMoneyInTheMachine;
    public TextMeshPro DisplayCodeFromInputs;
 
    public void UpdateDisplayCodeInputs(string SlotCode)
    {
        DisplayCodeFromInputs.text += SlotCode.ToString();
    }
    public void UpdateMoneyInVendingMachine(string Money)
    {
        DisplayMoneyInTheMachine.text = $"{Money}$";
    }
}
