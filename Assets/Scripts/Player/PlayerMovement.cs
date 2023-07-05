using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Medicine;

namespace PickleMan
{
    public class PlayerMovement : MonoBehaviour, CustomGameInput.IPlayerMovementActions
    {
        [Header("Base setup")]
        public float walkingSpeed = 7.5f;
        public float runningSpeed = 11.5f;
        public float jumpSpeed = 8.0f;
        public float gravity = 20.0f;
        public float lookSpeed = 2.0f;
        public float lookXLimit = 45.0f;
        public float cameraYOffset = 0.4f;

        public Camera playerCamera;
        [Inject] public Rigidbody rb { get; private set; }
        [Inject] public CapsuleCollider playerCol { get; private set; }

        public Vector3 m_MoveVelocity = Vector3.zero;
        public Vector3 m_MoveDirection = Vector3.zero;
        private Vector3 m_previousPosition;
        private Vector3 m_Displacement;
        private Vector2 m_InputDirection = Vector2.zero;
        private float m_RotationX = 0;
        private float m_currentMoveDirectionY = 0f;
        private bool m_IsSprinting = false;
        private bool m_jumpInitiated = false;
        private float m_previousTime;
        public CustomGameInput CustomGameInput { get; private set; }


        void Awake()
        {
            CustomGameInput = new CustomGameInput();
            CustomGameInput.Enable();
            CustomGameInput.PlayerMovement.SetCallbacks(this);
        }

        void Start()
        {

        }

        void Update()
        {
            UpdateMovementLogic();
            UpdateTransform();
            UpdateMovementState();
        }

        private void UpdateMovementLogic()
        {
            // We are grounded, so recalculate move direction based on axis
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
        }

        private void UpdateTransform()
        {
            // Camera
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        void UpdateMovementState()
        {

        }

        private void FixedUpdate()
        {

        }

        public void OnMove(InputAction.CallbackContext context)
        {
            m_InputDirection = context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            m_RotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            m_RotationX = Mathf.Clamp(m_RotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(m_RotationX, 0, 0);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                m_IsSprinting = true;
            }
            else if (context.canceled)
            {
                m_IsSprinting = false;
            }
        }
    }
}
