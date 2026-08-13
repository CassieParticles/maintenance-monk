using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using GameObjects.Tasks.Parts.DrawLine.Cursor;
using UnityEngine;

namespace GameObjects.Tasks.Parts.DrawLine
{
    public class DrawLinePart: Part
    {
        [SerializeField] private float distance;
        [NonSerialized] public float DifficultyScalar = 1.0f;

        [SerializeField] private DraggableCursor cursorPrefab;
        private DraggableCursor _cursor;

        [SerializeField] private int scoreChecks = 100;
        
        //Structure information
        private List<Vector2> _points;
        private List<Line> _lines;
        
        //While in play
        private int _currentLine;
        private float _scoreSum;
        private int _lastCheckedValue;
        
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

            _currentLine = -1;

            //Create the cursor object for the player
            _cursor = Instantiate(cursorPrefab);
            _cursor.gameObject.transform.position = _points[0];
            _cursor.gameObject.SetActive(false);
            
            //Set up scoring check

            _lastCheckedValue = 0;
        }
        
        public override void StartPart()
        {
            _currentLine = 0;
            
            _cursor.gameObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            if (_currentLine == -1)
            {
                return;
            }
            
            //Get how far along the line the cursor has moved
            float progress = _lines[_currentLine].GetIValue(_lines[_currentLine].ProjectPoint(_cursor.transform.position));

            if (progress > 1.0f)
            {
                _currentLine++;
                //TODO: Add final victory check
                return;
            }

            if (progress < 0.0f)
            {
                if (_currentLine > 0)
                {
                    _currentLine--;
                }
                return;
            }

            //Update the scores
            while (_currentLine * scoreChecks + progress * 100 > _lastCheckedValue)
            {
                float dist = _lines[_currentLine].DistanceFromLine(_cursor.transform.position);
                _scoreSum += Mathf.Max(1 - dist / (distance * DifficultyScalar), 0);
                _lastCheckedValue++;
            }
        }


        public override void FinishPart()
        {
            
        }
        
        public override void CleanupPart()
        {
            Destroy(_cursor.gameObject);
        }
        
        public override float FinalScore()
        {
            if (_currentLine == _lines.Count)
            {
                return _scoreSum / _lastCheckedValue;
            }

            return -1;
        }
    }
}