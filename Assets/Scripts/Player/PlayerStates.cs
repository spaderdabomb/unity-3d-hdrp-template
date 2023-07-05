using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PickleMan
{
    public class PlayerStates : MonoBehaviour
    {
        [field: SerializeField]
        public PlayerMovementState CurrentMovementState { get; private set; } = PlayerMovementState.None;
        void Start()
        {
        
        }

        void Update()
        {
        
        }

        [Flags]
        public enum PlayerMovementState
        {
            None = 0,
            Idling = 1,
            Walking = 2,
            Sprinting = 4,
            Jumping = 8,
            Crouching = 16,
            Immobile = 32
        }
    }
}
