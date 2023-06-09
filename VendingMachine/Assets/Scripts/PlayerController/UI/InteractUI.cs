using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerController
{
    public class InteractUI : MonoBehaviour
    {
        public RawImage normalCursor;
        public RawImage interactCursor;
        public Text moneyRepresentingText;


        private void Update()
        {
            moneyRepresentingText.text = $"Money: {GetComponent<CameraController>().Money.ToString("F2")}";
        }

    }
}
