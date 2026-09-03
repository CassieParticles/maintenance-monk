using System.Collections.Generic;
using UnityEngine;

namespace GameObjects.Tasks.Parts.StitchPart
{
    public class StitchPart: Part
    {
        [SerializeField] AK.Wwise.Event stitchSuccess;

        //Colliders
        private List<ColliderCheck> _checkColliders;
        private List<ColliderFail> _failColliders;

        //Score
        private List<float> _scores;
        private int _currentIndex;
        
        public override void InitPart()
        {
            //get check colliders
            _checkColliders = new List<ColliderCheck>(GetComponentsInChildren<ColliderCheck>());
            
            //Get fail colliders
            _failColliders = new List<ColliderFail>();

            _scores = new List<float>();
            
            StitchPart[] allStitches = transform.parent.GetComponentsInChildren<StitchPart>();
            bool onNewStitches = false;
            foreach (StitchPart stitch in allStitches)
            {
                //Skip to only stitches AFTER this one
                if (!onNewStitches && stitch != this)
                {
                    continue;
                }
                if (stitch == this)
                {
                    onNewStitches = true;
                    continue;
                }
                
                //Create fail colliders for each future part
                ColliderCheck[] colliders = stitch.GetComponentsInChildren<ColliderCheck>();
                foreach (ColliderCheck collider in colliders)
                {
                    GameObject newObj = Instantiate(collider.gameObject,transform);
                    Destroy(newObj.GetComponent<ColliderCheck>());
                    newObj.AddComponent<ColliderFail>();
                    _failColliders.Add(newObj.GetComponent<ColliderFail>());
                }
            }
            
            //Disable all check colliders
            foreach (ColliderCheck collider in _checkColliders)
            {
                collider.SetActive(false);
            }
        }
        public override void StartPart()
        {
            _checkColliders[0].SetActive(true);
            _checkColliders[_currentIndex].transform.localScale *= 1.2f;
            _currentIndex = 0;
        }
        public override void FinishPart()
        {
            
        }
        public override void CleanupPart()
        {
            foreach (ColliderFail col in _failColliders)
            {
                Destroy(col.gameObject);
            }
        }
        public override float FinalScore()
        {
            if (_scores.Count < _checkColliders.Count)
            {
                return -1;
            }

            float sumScore = 0;
            foreach (float score in _scores)
            {
                sumScore += score;
            }
            return sumScore /  _scores.Count;
        }

        public void NextStitch(float score)
        {
            //Deactivate the collider
            _checkColliders[_currentIndex].SetActive(false);
            _checkColliders[_currentIndex].transform.localScale /= 1.2f;
            _currentIndex++;

            stitchSuccess.Post(gameObject);

            //Add score if it's not been added yet
            if (_scores.Count < _currentIndex)
            {
                _scores.Add(score);
            }

            //If all scores have been gotten, then the part is done
            if (_scores.Count >= _checkColliders.Count)
            {
                return;
            }
            
            //Activate the next collider
            _checkColliders[_currentIndex].SetActive(true);
            _checkColliders[_currentIndex].transform.localScale *= 1.2f;
        }

        public void ResetProgress()
        {
            _checkColliders[_currentIndex].transform.localScale /= 1.2f;
            _checkColliders[_currentIndex].SetActive(false);
            _checkColliders[0].SetActive(true);
            _currentIndex = 0;
            _checkColliders[0].transform.localScale *= 1.2f;
        }
    }
}