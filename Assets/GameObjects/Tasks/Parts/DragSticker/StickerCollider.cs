using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts.DragSticker
{
    public class StickerCollider : MonoBehaviour
    {
        [NonSerialized] public bool ValidPlacement;
        
        private DragStickerPart _stickerPart;

        private bool _selected;

        private void Awake()
        {
            _stickerPart = GetComponentInParent<DragStickerPart>();
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