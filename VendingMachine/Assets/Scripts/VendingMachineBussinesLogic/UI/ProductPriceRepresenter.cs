using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VendingMachineBussinesLogic;

public class ProductPriceRepresenter : MonoBehaviour
{
    private string priceText;
    void Start()
    {
        priceText = GetComponentInParent<Slot>().price.ToString();
        UpdateText(priceText);

    }
    public void UpdateText(string price)
    {
        GetComponent<TextMeshPro>().text = price;
    }
   
}
