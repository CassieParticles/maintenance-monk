using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameObjects.Tasks.Parts.DragSticker
{
    [RequireComponent(typeof(Collider2D))]
    public class DragStickerPart: Part
    {
        private List<StickerCollider> _stickersToPlace;
        
        public override void InitPart()
        {
            _stickersToPlace = new  List<StickerCollider>();
            _stickersToPlace.AddRange(GetComponentsInChildren<StickerCollider>());

            foreach (var stickerCollider in _stickersToPlace)
            {
                stickerCollider.gameObject.SetActive(false);
            }
        }
        public override void StartPart()
        {
            foreach (var stickerCollider in _stickersToPlace)
            {
                stickerCollider.gameObject.SetActive(true);
            }
        }

        private void FixedUpdate()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //Add sticker back to stickers to place
            StickerCollider stickerCollider = other.GetComponent<StickerCollider>();
            if (stickerCollider)
            {
                stickerCollider.ValidPlacement = false;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            //Remove sticker from stickers to place
            StickerCollider stickerCollider = other.GetComponent<StickerCollider>();
            if (stickerCollider)
            {
                stickerCollider.ValidPlacement = true;
            }
        }

        public void RemoveSticker(StickerCollider stickerCollider)
        {
            _stickersToPlace.Remove(stickerCollider);
        }
        
        
        public override void FinishPart()
        {
            
        }
        public override void CleanupPart()
        {
            
        }
        public override float FinalScore()
        {
            if (_stickersToPlace.Count > 0)
            {
                return -1.0f;
            }

            return 1.0f;
        }
    }
}