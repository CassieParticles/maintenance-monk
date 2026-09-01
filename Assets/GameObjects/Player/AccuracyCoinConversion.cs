using System.Collections.Generic;
using UnityEngine;

namespace GameObjects.Player
{
    [CreateAssetMenu(fileName = "AccuracyCoinConversion", menuName = "Score/AccuracyCoinConversion")]
    public class AccuracyCoinConversion: ScriptableObject
    {
        //Upper threshold for coins
        public List<float> scoreThresholds;
        public List<int> coinRewards;
    }
}