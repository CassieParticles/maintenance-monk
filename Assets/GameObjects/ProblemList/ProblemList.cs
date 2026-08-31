using System;
using System.Collections.Generic;
using GameObjects.ProblemList.Problems;
using UnityEditorInternal;
using UnityEngine;

namespace GameObjects.ProblemList
{
    public class ProblemList : MonoBehaviour
    {
        [SerializeField] private ProblemEntry entryPrefab;
        
        private List<ProblemEntry> _entries;

        private void Awake()
        {
            _entries = new List<ProblemEntry>();
        }

        public void AddProblem(Problem problem)
        {
            ProblemEntry newEntry = Instantiate(entryPrefab,transform);
            newEntry.GiveProblem(problem);
            
            _entries.Add(newEntry);
            UpdateDisplay();
        }

        public void RemoveTask(ProblemEntry entry)
        {
            _entries.Remove(entry);
            UpdateDisplay();
        }
        
        private void UpdateDisplay()
        {
            float listWidth = GetComponent<RectTransform>().rect.width;
            float listHeight = GetComponent<RectTransform>().rect.height;
            for (int i = 0; i < _entries.Count; i++)
            {
                ProblemEntry entry =  _entries[i];
                RectTransform rectTransform = entry.GetComponent<RectTransform>();
                
                float entryHeight =  rectTransform.rect.height;
                
                float yPos = listHeight / 2 - i * entryHeight - entryHeight / 2;
                
                rectTransform.rect.Set(0,yPos,listWidth,entryHeight);
            }
        }
    }
}