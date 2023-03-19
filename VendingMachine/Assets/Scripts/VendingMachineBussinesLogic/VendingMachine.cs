using PlayerController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using VendingMachineBussinesLogic;

namespace VendingMachineBussinesLogic
{
    
    public class VendingMachine : MonoBehaviour
    {
        public float Money;
        [SerializeField] private Slot[] Slots;

        public GameObject ProductToPull;
        private void Start()
        {
            Slots = FindObjectsOfType<Slot>();
        }
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

        public void GetProductFromVendingMachine()
        {   
       
                ChoseProduct();
            
            
        }
        public void ChoseProduct()
        {
            if (FindObjectOfType<Display>().DisplayCodeFromInputs.text.Length >= 2)
                {
                foreach (Slot slot in Slots)
                {

                    if (slot.SlotNumber.IndexOf(FindObjectOfType<Display>().DisplayCodeFromInputs.text, StringComparison.OrdinalIgnoreCase) >= 0 && slot.productsInSlot.Count>0)
                    {
                       
                            ProductToPull = slot.productsInSlot.Where(item => item.transform != null)
                                        .OrderBy(item => item.transform.position.z)
                                        .FirstOrDefault().gameObject;
                            if(Money>= ProductToPull.GetComponentInParent<Slot>().price)
                        {
                            Money -= ProductToPull.GetComponentInParent<Slot>().price;
                            FindObjectOfType<Display>().UpdateMoneyInVendingMachine(Money.ToString("F2"));
                            
                            foreach (var item in ProductToPull.GetComponentInParent<Slot>().productsInSlot)
                            {
                                item.GetComponent<Item>().ArrangeAfterPullOfThisSlot();
                            }
                            ProductToPull.GetComponentInParent<Slot>().productsInSlot.Remove(ProductToPull);
                            ProductToPull.GetComponent<Item>().GoingOut();
                            WithdrowMoneyFromMachine();
                        }
                        else
                        {
                            
                        }
                           
                           
                           
                        
                    }
                    else
                    {
                        StartCoroutine(WrongProductNumber());
                    }
                }
            }
           
            
        }
        public IEnumerator WrongProductNumber()
        {
            MachineButton[] buttons = FindObjectsOfType<MachineButton>();
            foreach (MachineButton button in buttons) 
            {
                button.GetComponent<BoxCollider>().enabled = false;
            }
            yield return new WaitForSeconds(2f);
            foreach (MachineButton button in buttons)
            {
                button.GetComponent<BoxCollider>().enabled = true;
            }
            FindObjectOfType<Display>().DisplayCodeFromInputs.text = null;

            yield return 0;
        }
    }
  
}
