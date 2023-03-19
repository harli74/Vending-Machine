using PlayerController;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VendingMachineBussinesLogic
{
    public class MachineButton : MonoBehaviour
    {
        [SerializeField] private string letter;
        [SerializeField] private int ButtonType;
        public void ButtonPressed()
        {
            switch (ButtonType)
            {
                case 0:
                    InputButton();
                    break;
                    case 1:
                    PutMoneyInVendingMachineButton();
                    break;
                    case 2:
                    WithdrawMoneyButton();
                    break;
                default:
                    break;
            }
           
        }
        private void InputButton()

        {
            letter = GetComponentInChildren<TextMeshPro>().text;
            FindObjectOfType<Display>().UpdateDisplayCodeInputs(letter);
        }
        private void PutMoneyInVendingMachineButton()
        {
            if (FindObjectOfType<CameraController>().Money >1)
            {

                FindObjectOfType<VendingMachine>().PuttingMoneyInMachine(1);
            }
            else if(FindObjectOfType<CameraController>().Money > 0 && FindObjectOfType<CameraController>().Money <1)
            {
                FindObjectOfType<VendingMachine>().PuttingMoneyInMachine(FindObjectOfType<CameraController>().Money);
            }
           
        }
        private void WithdrawMoneyButton()
        {
            FindObjectOfType<VendingMachine>().WithdrowMoneyFromMachine();
        }
    }
}
