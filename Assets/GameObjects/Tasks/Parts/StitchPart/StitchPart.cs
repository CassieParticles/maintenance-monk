using System.Collections.Generic;
using UnityEngine;

namespace GameObjects.Tasks.Parts.StitchPart
{
    public class StitchPart: Part
    {
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
                collider.gameObject.SetActive(false);
            }
        }
        public override void StartPart()
        {
            _checkColliders[0].gameObject.SetActive(true);
            _currentIndex = 0;
        }
        public override void FinishPart()
        {
            
        }
        public override void CleanupPart()
        {
        }
        public override float FinalScore()
        {
            throw new System.NotImplementedException();
        }

        public void NextStitch()
        {
            
        }

        public void ResetProgress()
        {
            
        }
    }
}