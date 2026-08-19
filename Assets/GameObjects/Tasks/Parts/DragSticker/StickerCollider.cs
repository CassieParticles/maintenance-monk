using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts.DragSticker
{
    [RequireComponent(typeof(Collider2D))]
    public class StickerCollider : MonoBehaviour
    {
        private bool validPlacement;
        public bool ValidPlacement
        {
            get => validPlacement;
            set
            {
                validPlacement = value;
                if (value)
                {
                    _spriteRenderer.color = new Color32(255, 255, 255, 255);
                }
                else
                {
                    _spriteRenderer.color = new Color32(255, 0, 0, 255);
                }
            }
        }

        private DragStickerPart _stickerPart;

        private bool _selected;
        
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _stickerPart = GetComponentInParent<DragStickerPart>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            ValidPlacement = false;
        }

        private void OnMouseDown()
        {
            if (!ValidPlacement)
            {
                _selected = true;
            }
        }

        private void OnMouseUp()
        {
            //Only do this if already selected
            if (!_selected)
            {
                return;
            }
            
            _selected = false;
            if (ValidPlacement)
            {
                _stickerPart.RemoveSticker(this);
            }
        }

        private void FixedUpdate()
        {
            //Move sticker to follow mouse
            if (_selected)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = mousePosition;
            }
        }
    }
}