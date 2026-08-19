using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts.DragSticker
{
    [RequireComponent(typeof(Collider2D))]
    public class DragStickerPart: Part
    {
        public override void InitPart()
        {
            throw new System.NotImplementedException();
        }
        public override void StartPart()
        {
            throw new System.NotImplementedException();
        }

        private void FixedUpdate()
        {
            throw new NotImplementedException();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            throw new NotImplementedException();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            throw new NotImplementedException();
        }


        public override void FinishPart()
        {
            throw new System.NotImplementedException();
        }
        public override void CleanupPart()
        {
            throw new System.NotImplementedException();
        }
        public override float FinalScore()
        {
            throw new System.NotImplementedException();
        }
    }
}