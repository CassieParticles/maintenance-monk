using System;
using UnityEngine;

namespace GameObjects.Tasks.Parts
{
    public abstract class Part : MonoBehaviour
    {
        [NonSerialized] public float DifficultyScalar = 1.0f;
        
        public abstract void InitPart();
        //Call to begin the part
        public abstract void StartPart();
        //Call to end the part
        public abstract void FinishPart();
        //call to cleanup the part
        public abstract void CleanupPart();
        //Return -1 when game isn't finished, 0->1 otherwise
        public abstract float FinalScore();
    }
}