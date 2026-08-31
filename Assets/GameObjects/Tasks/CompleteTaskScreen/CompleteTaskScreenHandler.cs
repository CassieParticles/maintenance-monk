using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace GameObjects.Tasks.CompleteTaskScreen
{
    public class CompleteTaskScreenHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeDisplay;
        [SerializeField] private TextMeshProUGUI accuracyDisplay;

        [NonSerialized] public bool moveOn;
        
        private void Awake()
        {
            if (timeDisplay == null || accuracyDisplay == null)
            {
                Debug.LogWarning("WARNING: TIME DISPLAY OR ACCURACY DISPLAY NOT SET");
            }
            
            gameObject.SetActive(false);
            moveOn = false;
        }

        public void StartScreen(TaskResults results)
        {
            moveOn = false;
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
            
            gameObject.SetActive(true);
            
            //TODO: Display coins and reputation
        }

        public void CloseScreen()
        {
            moveOn = true;
            gameObject.SetActive(false);
        }
    }
}