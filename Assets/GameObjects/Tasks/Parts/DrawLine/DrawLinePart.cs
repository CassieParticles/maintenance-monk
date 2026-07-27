using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameObjects.Tasks.Parts.DrawLine
{
    public class DrawLinePart: Part
    {
        [SerializeField] private float distance;
        [NonSerialized] public float DifficultyScalar = 1.0f;
        
        //Structure information
        private List<Vector2> _points;
        private List<Line> _lines;
        private List<PolygonCollider2D> _colliders;
        
        public override void InitPart()
        {
            _points = new List<Vector2>();
            //Gather the vertices
            for (int i = 0; i < transform.childCount; i++)
            {
                _points.Add(transform.GetChild(i).position);
                transform.GetChild(i).gameObject.SetActive(false);
            }
            
            //Create the lines
            _lines = new List<Line>();
            for (int i = 0; i < _points.Count - 1; i++)
            {
                _lines.Add(new Line(_points[i],_points[i + 1]));
            }
            
            //Generate the colliders
            _colliders = new List<PolygonCollider2D>();
            foreach (Line line in _lines)
            {
                Vector2 normal = new Vector2(-line.DirectionNorm.y, line.DirectionNorm.x);
                
                GameObject obj = new GameObject("Collider");
                obj.transform.position = transform.position;
                obj.transform.parent = transform;
                
                Vector2[] points = new Vector2[]
                {
                    line.A + normal * distance * DifficultyScalar,
                    line.B + normal * distance * DifficultyScalar,
                    line.B + line.DirectionNorm * distance * DifficultyScalar,
                    line.B - normal * distance * DifficultyScalar,
                    line.A - normal * distance * DifficultyScalar,
                    line.A - line.DirectionNorm * distance * DifficultyScalar,
                };
                
                PolygonCollider2D collider = obj.AddComponent<PolygonCollider2D>();
                collider.isTrigger = true;
                collider.SetPath(0,points);
                
                obj.AddComponent<ColliderMessage>();
                
                //Add rigid body so OnTriggerEnter can be called
                Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Kinematic;
                
                collider.gameObject.SetActive(false);
                _colliders.Add(collider);
            }
        }
        
        public override void StartPart()
        {
            
        }
        public override void FinishPart()
        {
            
        }
        
        public override void CleanupPart()
        {
            foreach (PolygonCollider2D col in _colliders)
            {
                Destroy(col.gameObject);
            }
        }
        
        public override float FinalScore()
        {
            return -1.0f;
        }
    }
}