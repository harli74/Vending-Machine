using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VendingMachineBussinesLogic;

public class AnimHolder : MonoBehaviour
{
    // Start is called before the first frame update
 public void DestroyItem()
    {
        Destroy(GetComponentInChildren<Item>().gameObject);
        
    }
}
