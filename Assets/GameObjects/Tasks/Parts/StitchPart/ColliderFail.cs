using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts.StitchPart
{
    [RequireComponent(typeof(Collider2D))]
    public class ColliderFail : MonoBehaviour
    {
        private StitchPart _parentPart;

        private void Awake()
        {
            throw new NotImplementedException();
        }

        private void OnMouseDown()
        {
            throw new NotImplementedException();
        }
    }
}