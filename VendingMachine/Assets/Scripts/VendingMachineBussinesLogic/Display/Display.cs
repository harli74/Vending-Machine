using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    public TextMeshPro DisplayMoneyInTheMachine;
    public TextMeshPro DisplayCodeFromInputs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDisplayCodeInputs(string SlotCode)
    {
        DisplayCodeFromInputs.text += SlotCode.ToString();
    }
    public void UpdateMoneyInVendingMachine(string Money)
    {
        DisplayMoneyInTheMachine.text = $"{Money.ToString()}$";
    }
}
