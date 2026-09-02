using GameObjects.Player;
using GameObjects.ProblemList.Problems;
using TMPro;
using UnityEngine;

namespace GameObjects.ProblemList.Person
{
    public class Person : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI chatMessage;
        
        private ProblemList _problemList;
        private Problem _problem;
        
        public void SetUpPerson(Problem problem)
        {
            _problemList = FindAnyObjectByType<ProblemList>();
            _problem = problem;

            chatMessage.text = _problem.message;

            PlayerData.Instance.State = PlayerStates.Talking;
            
            GetComponent<RectTransform>().anchoredPosition = new Vector2(-557, 133);
        }

        public void ClosePerson()
        {
            _problemList.AddProblem(_problem);
            
            PlayerData.Instance.State = PlayerStates.Waiting;
            
            Destroy(gameObject);
        }
    }
}