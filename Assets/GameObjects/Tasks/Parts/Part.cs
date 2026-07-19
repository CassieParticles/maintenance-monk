using UnityEngine;

namespace GameObjects.Tasks.Parts
{
    public abstract class Part : MonoBehaviour
    {
        public abstract void InitPart();
        //Call to begin the part
        public abstract void StartPart();
        //Call to end the part
        public abstract void FinishPart();
        //Return -1 when game isn't finished, 0->1 otherwise
        public abstract float FinalScore();
    }
}