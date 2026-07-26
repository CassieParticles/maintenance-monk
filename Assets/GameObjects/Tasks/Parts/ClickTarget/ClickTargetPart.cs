using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts.ClickTarget
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ClickTargetPart : Part
    {
        [SerializeField] private float radius;
        [NonSerialized] public float DifficultyScalar = 1.0f;
        
        CircleCollider2D _circleCollider;

        private float _score;
        private bool _active;
        
        public override void InitPart()
        {
            _circleCollider = GetComponent<CircleCollider2D>();
            _circleCollider.radius = radius * DifficultyScalar;
            _circleCollider.isTrigger = true;

            _score = -1;
            _active = false;
        }
        public override void StartPart()
        {
            _active = true;
        }

        private void OnMouseDown()
        {
            if (!_active)
            {
                return;
            }
            
            //Get the mouse position
            Vector2 mousePostiton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distance = ((Vector2)transform.position - mousePostiton).magnitude;

            _score = 1 - (distance / (radius * DifficultyScalar));
        }

        public override void FinishPart()
        {
            _active = false;
        }
        public override void CleanupPart()
        {
            
        }
        public override float FinalScore()
        {
            return _score;
        }
    }
}