using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts.DragSticker
{
    public class StickerCollider : MonoBehaviour
    {
        [NonSerialized] public bool ValidPlacement;

        private bool _selected;

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