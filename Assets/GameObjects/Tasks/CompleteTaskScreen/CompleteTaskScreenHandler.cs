using System;
using System.Text;
using GameObjects.Player;
using TMPro;
using UnityEngine;

namespace GameObjects.Tasks.CompleteTaskScreen
{
    public class CompleteTaskScreenHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeDisplay;
        [SerializeField] private TextMeshProUGUI accuracyDisplay;

        [SerializeField] private TextMeshProUGUI coinsDisplay;
        [SerializeField] private TextMeshProUGUI reputationDisplay;

        public bool MoveOn { get; private set; }
        
        private PlayerData _playerData;

        private void Awake()
        {
            if (timeDisplay == null || accuracyDisplay == null)
            {
                Debug.LogWarning("WARNING: TIME DISPLAY OR ACCURACY DISPLAY NOT SET");
            }
            
            gameObject.SetActive(false);
            MoveOn = false;

            _playerData = PlayerData.Instance;
        }

        public void StartScreen(TaskResults results)
        {
            MoveOn = false;
            if (timeDisplay != null)
            {
                int secondsNearest = (int)results.Time;
                int minutes = secondsNearest / 60;
                secondsNearest %= 60;
                
                StringBuilder displayTime = new StringBuilder();

                if (minutes > 10)
                {
                    displayTime.Append(0);
                }
                displayTime.Append(minutes);
                displayTime.Append(":");

                if (secondsNearest < 10)
                {
                    displayTime.Append("0");
                }
                
                displayTime.Append(secondsNearest);
                
                timeDisplay.text = displayTime.ToString();
            }

            if (accuracyDisplay != null)
            {
                StringBuilder displayAccuracy = new StringBuilder();
                int accuracyPercent = (int)(results.Score * 100);
                
                displayAccuracy.Append(accuracyPercent);
                displayAccuracy.Append("%");
                
                accuracyDisplay.text = displayAccuracy.ToString();
            }

            if (coinsDisplay != null)
            {
                coinsDisplay.text = _playerData.Coins.ToString();
                reputationDisplay.text = _playerData.Reputation.ToString();
            }
            
            gameObject.SetActive(true);
        }

        public void CloseScreen()
        {
            MoveOn = true;
            gameObject.SetActive(false);
        }
    }
}