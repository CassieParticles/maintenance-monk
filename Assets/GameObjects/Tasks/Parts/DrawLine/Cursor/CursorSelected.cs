using System;
using UnityEngine;

namespace GameObjects.Minigame.MinigameParts.DragLines
{
    public class NewMonoBehaviourScript : MonoBehaviour
    {
        private Cursor _parentCursor;
        
        private void Awake()
        {
            _parentCursor = GetComponentInParent<Cursor>();
        }

        private void OnMouseDown()
        {
            _parentCursor.Selected = true;
        }

        private void OnMouseUp()
        {
            _parentCursor.Selected = false;
        }
    }
}
