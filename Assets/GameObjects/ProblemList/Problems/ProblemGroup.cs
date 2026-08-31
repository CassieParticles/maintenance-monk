using System.Collections.Generic;
using UnityEngine;

namespace GameObjects.ProblemList.Problems
{
    [CreateAssetMenu(fileName = "ProblemGroup", menuName = "Tasks/ProblemGroup", order = 1)]
    public class ProblemGroup : ScriptableObject
    {
        public List<Problem> problems;
        
        public Problem GetRandomProblem()
        {
            return problems[Random.Range(0, problems.Count)];
        }
    }
}