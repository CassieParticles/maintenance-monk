using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameObjects.Minigame.MinigameParts.DragLines
{
    [RequireComponent(typeof(PlayerInput))]
    public class Cursor : MonoBehaviour
    {
        private PlayerInput _playerInput;
        
        [NonSerialized]
        public bool Selected;

        private Vector2 _cursorPosition;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            _playerInput.actions.FindAction("CursorPosition").performed += GetMousePosition;
        }

        private void OnDisable()
        {
            _playerInput.actions.FindAction("CursorPosition").performed -= GetMousePosition;
        }

        private void GetMousePosition(InputAction.CallbackContext context)
        {
            _cursorPosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        }

        private void FixedUpdate()
        {
            if (Selected)
            {
                transform.position = _cursorPosition;
            }
        }
    }
}