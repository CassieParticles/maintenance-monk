using System.Collections.Generic;
using UnityEngine;

namespace GameObjects.Player
{
    [CreateAssetMenu(fileName = "AccuracyRepConversion", menuName = "Score/AccuracyRepConversion")]
    public class AccuracyRepConversion: ScriptableObject
    {
        //Upper threshold for coins
        public List<float> scoreThresholds;
        public List<float> repRewards;
    }
}