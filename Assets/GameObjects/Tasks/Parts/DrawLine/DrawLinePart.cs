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
        
        //Forgiveness check
        private readonly float _forgivenessThreshold = 0.9f;
        private float _lastUpdateProgress;
        
        //Drawing the line the player draws
        DrawTexture _texture;
        
        
        public override void InitPart()
        {
            _points = new List<Vector2>();
            
            //Get the bounds of the drawn line
            Vector2 minCorner = new Vector2(float.MaxValue, float.MaxValue);
            Vector2 maxCorner = new Vector2(float.MinValue, float.MinValue);
            
            //Gather the vertices
            for (int i = 0; i < transform.childCount; i++)
            {
                Vector2 position = transform.GetChild(i).position;
                
                _points.Add(position);
                transform.GetChild(i).gameObject.SetActive(false);
                
                //Get the bounds
                minCorner.x = Mathf.Min(minCorner.x, position.x);
                minCorner.y = Mathf.Min(minCorner.y, position.y);
                
                maxCorner.x = Mathf.Max(maxCorner.x, position.x);
                maxCorner.y = Mathf.Max(maxCorner.y, position.y);
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
            
            //Setting up the texture to draw to
            GameObject obj = new GameObject();
            obj.AddComponent<SpriteRenderer>();
            _texture = obj.AddComponent<DrawTexture>();
            
            Vector2 centre = (minCorner + maxCorner) / 2; 
            Vector2 size = (maxCorner - minCorner) + Vector2.one;
            
            _texture.InitTexture(centre, size);
        }
        
        public override void StartPart()
        {
            _currentLine = 0;
            _lastUpdateProgress = 0;
            
            _cursor.gameObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            if (_currentLine == -1)
            {
                return;
            }
            _texture.Draw(_cursor.transform.position,0.1f,Color.black);
            
            //Get how far along the line the cursor has moved
            float progress = _lines[_currentLine].GetIValue(_lines[_currentLine].ProjectPoint(_cursor.transform.position));

            if (progress > 1.0f || _lastUpdateProgress > _forgivenessThreshold && _lastUpdateProgress > progress)
            {
                _currentLine++;
                _lastUpdateProgress = 0;
                return;
            }

            //Update the scores
            while (_currentLine * scoreChecks + progress * 100 > _lastCheckedValue)
            {
                float dist = _lines[_currentLine].DistanceFromLine(_cursor.transform.position);
                _scoreSum += Mathf.Max(1 - dist / (distance * DifficultyScalar), 0);
                _lastCheckedValue++;
            }

            _lastUpdateProgress = progress;
        }


        public override void FinishPart()
        {
            _cursor.gameObject.SetActive(false);
        }
        
        public override void CleanupPart()
        {
            Destroy(_cursor.gameObject);
            
            Destroy(_texture.gameObject);
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