using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts.StitchPart
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ColliderCheck : MonoBehaviour
    {
        private StitchPart _parentPart;
        private CircleCollider2D _collider2D;

        private void Awake()
        {
            _parentPart = GetComponentInParent<StitchPart>();
            _collider2D = GetComponent<CircleCollider2D>();
        }

        private void OnMouseDown()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            float distance =  Vector2.Distance(mousePosition, transform.position);
            float score = 1 - (distance / _collider2D.radius);    
            
            
            _parentPart.NextStitch(score);
        }
    }
}