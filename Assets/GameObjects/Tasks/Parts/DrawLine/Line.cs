using System.Collections.Generic;
using UnityEngine;

namespace GameObjects.Tasks.Parts.DrawLine
{
    public struct Line
    {
        public Line(Vector2 a, Vector2 b)
        {
            A = a;
            B = b;
        }
        
        public Vector2 A;
        public Vector2 B;
        
        public Vector2 Direction => B - A;
        public Vector2 DirectionNorm =>Direction.normalized;

        //Project the point onto the line (finds the closest point on line, useful for perpendicular distance)
        public Vector2 ProjectPoint(Vector2 point)
        {
            Vector2 AP = point - A;
            return A + Vector2.Dot(DirectionNorm, AP) * DirectionNorm;
        }
        
        //Get the perpendicular distance from the line
        public float DistanceFromLine(Vector2 point)
        {
            Vector2 projectedPoint = ProjectPoint(point);
            return Vector2.Distance(A, projectedPoint);
        }
        
        //Get the value of i from a point on the line
        public float GetIValue(Vector2 point)
        {
            return (point.x - A.x) / Direction.x;
        }
    }
}