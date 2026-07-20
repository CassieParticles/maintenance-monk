using System;
using System.Collections.Generic;
using GameObjects.Tasks.Parts;
using UnityEngine;

namespace GameObjects.Tasks
{
    public class Task : MonoBehaviour
    {
        //List of all parts for the task
        private Part[] _parts;
        
        private int _currentPartIndex;
        
        private float _cumulativeScore;
        

        //Return -1 when score is under play, return the cumulative score otherwise
        public float Score
        {
            get
            {
                if (_currentPartIndex >= 0)
                {
                    return -1;
                }
                return _cumulativeScore / _parts.Length; 
            }
        }

        private void Awake()
        {
            _parts = GetComponentsInChildren<Part>();
        }

        //Call upon creation of the task, initialized everything
        public void InitTask()
        {
            foreach (Part part in _parts)
            {
                part.InitPart();
                part.gameObject.SetActive(false);
            }
            //index -1 tells the fixed update loop the task hasn't started yet
            _currentPartIndex = -1;
        }

        //Start the task, starys playing
        public void StartTask()
        {
            _currentPartIndex = 0;
            _parts[0].gameObject.SetActive(true);
            _parts[0].StartPart();
        }
        
        //Finish task, player has either completed or exited the task
        public void FinishTask()
        {
            //If finishing tasks midway, reset part
            if (_currentPartIndex < _parts.Length)
            {
                _parts[_currentPartIndex].FinishPart();
                _parts[_currentPartIndex].gameObject.SetActive(false);
            }
            CleanupTask();
        }

        //Clean up the task
        public void CleanupTask()
        {
            foreach (Part part in _parts)
            {
                part.CleanupPart();
            }
            _currentPartIndex = -1;
        }

        private void FixedUpdate()
        {
            //Task not started yet
            if (_currentPartIndex < 0)
            {
                return;
            }
            float score = _parts[_currentPartIndex].FinalScore();
            //Part not yet complete (-1 only valid return below 0)
            if (score < 0)
            {
                return;
            }
            //Task must be complete, log score, then start next part
            _cumulativeScore += score;
            
            _parts[_currentPartIndex].FinishPart();
            _parts[_currentPartIndex].gameObject.SetActive(false);
            _currentPartIndex++;
            
            //If there is a next part, start that then return
            if (_currentPartIndex < _parts.Length)
            {
                _parts[_currentPartIndex].gameObject.SetActive(true);
                _parts[_currentPartIndex].StartPart();
                return;
            }
            //Final part complete
            FinishTask();
        }
    }
}