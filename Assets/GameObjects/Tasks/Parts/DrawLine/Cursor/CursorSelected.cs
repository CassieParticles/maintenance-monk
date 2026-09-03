using System;
using GameObjects.Tasks.Parts.DrawLine.Cursor;
using UnityEngine;

namespace GameObjects.Minigame.MinigameParts.DragLines
{
    public class NewMonoBehaviourScript : MonoBehaviour
    {
        [SerializeField] AK.Wwise.Event penClick;

        private DraggableCursor _parentCursor;
        
        private void Awake()
        {
            _parentCursor = GetComponentInParent<DraggableCursor>();
        }

        private void OnMouseDown()
        {
            _parentCursor.Selected = true;
            penClick.Post(gameObject);
        }

        private void OnMouseUp()
        {
            _parentCursor.Selected = false;
        }
    }
}
