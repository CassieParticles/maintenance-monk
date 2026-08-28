using System;
using GameObjects.ProblemList.Problems;
using GameObjects.Tasks;
using TMPro;
using UnityEngine;

namespace GameObjects.ProblemList
{
    public class ProblemEntry : MonoBehaviour
    {
        private Problem _problem;
        
        private TextMeshProUGUI _buttonText;
        private Task _task;

        private void Awake()
        {
            _buttonText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void GiveProblem(Problem problem)
        {
            //Set up button
            this._problem = problem;
            _buttonText.text = problem.title;
            
            //Initialize the task
            _task = Instantiate(problem.taskPrefab);
            _task.InitTask();
        }

        public void StartTask()
        {
            Debug.Log("Starting task:");
            
            _task.StartTask();
        }

        private void FixedUpdate()
        {
            if (_task.Score.Score < 0)
            {
                return;
            }
            
            Debug.Log("Player Score: " + _task.Score.Score + " Player Time: " +  _task.Score.Time);
        }
    }
}