using System;
using System.Collections;
using GameObjects.Player;
using GameObjects.ProblemList.Problems;
using UnityEngine;

namespace GameObjects.ProblemList
{
    public class ProblemListPopulator : MonoBehaviour
    {
        [SerializeField] AK.Wwise.Event npcEnter;

        [SerializeField] private ProblemGroup group;
        [SerializeField] private float spawnRate = 5;
        [SerializeField] private Person.Person personPrefab;
        
        private Coroutine _spawnCoroutine;
        private ProblemList _problemList;

        private void OnEnable()
        {
            _problemList = GetComponent<ProblemList>();
            _spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }

        private void OnDisable()
        {
            StopCoroutine(_spawnCoroutine);
        }

        private IEnumerator SpawnCoroutine()
        {
            yield return new WaitForSeconds(spawnRate);

            if (PlayerData.Instance.State == PlayerStates.Waiting)
            {
                Person.Person person = Instantiate(personPrefab,FindAnyObjectByType<Canvas>().transform);
                person.SetUpPerson(group.GetRandomProblem());
                npcEnter.Post(gameObject);
            }
            
            StartCoroutine(SpawnCoroutine());
        }
    }
}