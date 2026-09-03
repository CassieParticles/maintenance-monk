using System;
using GameObjects.Player;
using GameObjects.ProblemList.Problems;
using GameObjects.Tasks;
using GameObjects.Tasks.CompleteTaskScreen;
using TMPro;
using UnityEngine;

namespace GameObjects.ProblemList
{
    public class ProblemEntry : MonoBehaviour
    {
        private Problem _problem;
        
        private TextMeshProUGUI _buttonText;
        private Task _task;

        private bool _taskStarted = false;

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
            if (PlayerData.Instance.State != PlayerStates.Waiting)
            {
                return;
            }
            
            Debug.Log("Starting task:");
            _taskStarted = true;
            PlayerData.Instance.State = PlayerStates.InGame;
            
            _task.StartTask();
        }

        private void FixedUpdate()
        {
            if (!_taskStarted)
            {
                return;
            }
            if (_task.Score.Score < 0)
            {
                return;
            }
            
            //Task is complete
            CompleteTaskScreenHandler completeScreen = FindAnyObjectByType<CompleteTaskScreenHandler>(FindObjectsInactive.Include);
            if (completeScreen !=null && !completeScreen.IsOpen)
            {
                completeScreen.StartScreen(_task.Score);
            }
            
            //Handle display screen
            if (completeScreen != null && !completeScreen.MoveOn)
            {
                return;
            }
            
            //Task is finished
            _task.CleanupTask();
            completeScreen.IsOpen = false;
            GetComponentInParent<ProblemList>().RemoveTask(this);
            Destroy(_task.gameObject);
            Destroy(gameObject);
            PlayerData.Instance.State = PlayerStates.Waiting;
        }
    }
}