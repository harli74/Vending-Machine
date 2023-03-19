using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VendingMachineBussinesLogic;

namespace PlayerController
{
    public class CameraController : MonoBehaviour
    {
        public float Money;
        [SerializeField] private float sensitivity = 2.5f;
        [SerializeField] private float yMin = -80f;
        [SerializeField] private float yMax = 80f;
        [SerializeField] private float xMin = -360f;
        [SerializeField] private float xMax = 360f;

        private float _rotationX;
        private float _rotationY;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _rotationX = transform.localEulerAngles.y;
            _rotationY = -transform.localEulerAngles.x;
        }

        void Update()
        {
            _rotationX += Input.GetAxis("Mouse X") * sensitivity;
            _rotationY += Input.GetAxis("Mouse Y") * sensitivity;
            _rotationY = Mathf.Clamp(_rotationY, yMin, yMax);
            _rotationX = Mathf.Clamp(_rotationX, xMin, xMax);

            transform.localEulerAngles = new Vector3(-_rotationY, _rotationX, 0);
            RaycastTargeting();
        }

        public void RaycastTargeting()
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                //todo
                //if press leftMouseButton Interact();
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
                if(hit.collider.gameObject.tag == "Interactable")
                {
                    InputMouseButtonForInteraction(hit);
                    CursorUpdate(true);
                }
                else
                {
                    CursorUpdate(false);
                }
            }
        }
        public void CursorUpdate(bool Interactable)
        {
            if (Interactable)
            {
                GetComponent<InteractUI>().normalCursor.enabled = false;
                GetComponent<InteractUI>().interactCursor.enabled = true;
            }
            else
            {
                GetComponent<InteractUI>().normalCursor.enabled = true;
                GetComponent<InteractUI>().interactCursor.enabled = false;
            }
        }
        public void InputMouseButtonForInteraction(RaycastHit hit)
        {
            if(Input.GetMouseButtonDown(0))
            {
                
                hit.collider.GetComponent<MachineButton>().ButtonPressed();
            }
        }
    }
}
