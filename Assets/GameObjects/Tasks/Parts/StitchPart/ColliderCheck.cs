using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts.StitchPart
{
    [RequireComponent(typeof(Collider2D))]
    public class ColliderCheck : MonoBehaviour
    {
        private StitchPart _parentPart;

        private void Awake()
        {
            _parentPart = GetComponentInParent<StitchPart>();
        }

        private void OnMouseDown()
        {
            _parentPart.NextStitch();
        }
    }
}