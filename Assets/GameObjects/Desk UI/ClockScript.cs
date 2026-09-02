using GameObjects.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockScript : MonoBehaviour
{
    [SerializeField] float DayLength = 180;
    float DayProgress = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartDay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDay() {
        transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 135);
        StartCoroutine(DayCycle());
    }

    void EndDay() {
        SceneManager.LoadSceneAsync(2);
    }

    public IEnumerator DayCycle() {
        while (DayProgress < DayLength) {
            yield return new WaitForFixedUpdate();
            DayProgress += Time.fixedDeltaTime;
            float rotationValue = 135 + 225 * (DayProgress / DayLength);
            transform.GetChild(0).rotation = Quaternion.Euler(0, 0, rotationValue);
            
        }
        while (PlayerData.Instance.State != PlayerStates.Waiting) {
            yield return new WaitForFixedUpdate();
        }
        EndDay();
    }
}
