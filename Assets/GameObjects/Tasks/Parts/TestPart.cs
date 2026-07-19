using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts
{
    public class TestPart: Part
    {
        private float _timer;
        public override void InitPart()
        {
            _timer = -1;
        }
        public override void StartPart()
        {
            _timer = 0;
        }

        public override void FinishPart()
        {
            Debug.Log(gameObject.name + " finished");
        }

        public override float FinalScore()
        {
            if (_timer < 3)
            {
                return -1;
            }

            return 0.67f;
        }

        private void FixedUpdate()
        {
            if (_timer >= 0)
            {
                _timer += Time.fixedDeltaTime;
            }
        }
    }
}