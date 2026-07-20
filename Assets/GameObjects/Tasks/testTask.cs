using System;
using UnityEngine;

namespace GameObjects.Tasks
{
    //TESTING SCRIPT, IMMEDIATELY INITIALIZE THEN START THE TASK
    public class testTask : MonoBehaviour
    {
        private Task _task;

        private void Awake()
        {
            _task = GetComponent<Task>();
        }

        private void Start()
        {
            _task.InitTask();
            _task.StartTask();
        }

        private void FixedUpdate()
        {
            float score = _task.Score;
            if (score > 0)
            {
                Debug.Log("Final score is: " + score);
            }
        }
    }
}