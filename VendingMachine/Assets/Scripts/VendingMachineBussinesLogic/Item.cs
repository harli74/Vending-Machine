using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VendingMachineBussinesLogic;

namespace VendingMachineBussinesLogic
{
    
    public class Item : MonoBehaviour
    {
        private GameObject animHolder;
        private void Start()
        {
            animHolder = FindObjectOfType<AnimHolder>().gameObject;
        }
        public void GoingOut()
        {
            transform.parent = animHolder.transform;
            transform.position = new Vector3(animHolder.transform.position.x, animHolder.transform.position.y, animHolder.transform.position.z);
            animHolder.GetComponent<Animator>().Play("EatingAnim");
        }

        public void ArrangeAfterPullOfThisSlot()
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - GetComponentInParent<Slot>().spacing);
        }
    }
}
