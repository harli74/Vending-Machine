using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VendingMachineBussinesLogic
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] public float price;
        
        [SerializeField] GameObject product;
        [SerializeField]
        [Tooltip("recomended 5")]
        private int ProductsCount;

        [SerializeField] private List<GameObject> productsInSlot = new List<GameObject>();
        
        [SerializeField]
        [Tooltip("recomended 0.1f")]
        private float spacing = 0.1f;

        [SerializeField] private string SlotNumber;

        void Start()
        {
            productsInSlot = new List<GameObject>();
            float spaceBetweenProducts = 0;
                 for (int i = 0; i < ProductsCount; i++)
                    {
                        if (i > 0)
                        {
                    spaceBetweenProducts = spaceBetweenProducts + spacing;
                        };
                        
                        Vector3 SlotAdjustment = new Vector3(transform.position.x, transform.position.y, transform.position.z + spaceBetweenProducts);
                        GameObject Cloneproduct = Instantiate(product, SlotAdjustment, product.transform.rotation,transform);
                        productsInSlot.Add(Cloneproduct);
                    }

                 //todo   ne e nalichen item logika
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
