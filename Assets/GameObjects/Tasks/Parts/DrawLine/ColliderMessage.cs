using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts.DrawLine
{
    public class ColliderMessage : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Enter: "+other.name);
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("Exit: "+other.name);
        }
    }
}