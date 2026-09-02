using GameObjects.Player;
using GameObjects.ProblemList.Problems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace GameObjects.ProblemList.Person
{
    public class Person : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI chatMessage;
        [SerializeField] private Image image;
        
        private ProblemList _problemList;
        private Problem _problem;
        
        public void SetUpPerson(Problem problem)
        {
            _problemList = FindAnyObjectByType<ProblemList>();
            _problem = problem;

            chatMessage.text = _problem.message;
            image.sprite = _problem.personSprite;

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