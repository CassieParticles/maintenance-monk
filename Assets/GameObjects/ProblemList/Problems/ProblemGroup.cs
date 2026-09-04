using System.Collections.Generic;
using UnityEngine;

namespace GameObjects.ProblemList.Problems
{
    [CreateAssetMenu(fileName = "ProblemGroup", menuName = "Tasks/ProblemGroup", order = 1)]
    public class ProblemGroup : ScriptableObject
    {
        public List<Problem> problems;

        private int _previousIndex = -1;
        
        public Problem GetRandomProblem()
        {
            int randomIndex = Random.Range(0, problems.Count);

            if (randomIndex == _previousIndex)
            {
                randomIndex++;
                randomIndex = randomIndex %  problems.Count;
            }
            _previousIndex = randomIndex;
            
            return problems[randomIndex];
        }
    }
}