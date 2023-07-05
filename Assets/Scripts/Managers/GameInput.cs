using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PickleMan
{
    public class GameInput : MonoBehaviour, CustomGameInput.IGameInputActions
    {
        void Start()
        {
        
        }

        void Update()
        {
        
        }

        public void OnMenuToggled(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
        }
    }
}
