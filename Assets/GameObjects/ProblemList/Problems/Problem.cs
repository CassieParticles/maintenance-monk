using GameObjects.Tasks;
using UnityEngine;

namespace GameObjects.ProblemList.Problems
{
    [CreateAssetMenu(fileName = "Problem", menuName = "Tasks/Problem", order = 0)]
    public class Problem : ScriptableObject
    {
        public string title;
        [TextArea(5,20)]public string message;

        public Sprite personSprite;

        public Task taskPrefab;
    }
}