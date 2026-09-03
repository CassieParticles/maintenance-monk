using GameObjects.Player;
using GameObjects.ProblemList;
using UnityEngine;
using UnityEngine.UI;

public class HideUI : MonoBehaviour
{

    GameObject Background;
    ClockScript Clock;
    GameObject ReputationBar;
    CoinScript CoinCounter;
    GameObject ProblemList;
    public bool hiddenBool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Background = transform.Find("Background").gameObject;
        Clock = transform.GetComponentInChildren<ClockScript>();
        ReputationBar = transform.GetComponentInChildren<ReputationBar>().gameObject;
        CoinCounter = transform.GetComponentInChildren<CoinScript>();
        ProblemList = transform.GetComponentInChildren<ProblemList>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hiddenBool && PlayerData.Instance.State == PlayerStates.InGame) {
            HideAll();
        } else if (hiddenBool && PlayerData.Instance.State != PlayerStates.InGame) {
            HideAll();
        }
    }
    [ContextMenu("Hide")]
    public void HideAll() {
        hiddenBool = !hiddenBool;

        Background.SetActive(!hiddenBool);
        Clock.HideClock(hiddenBool);
        ReputationBar.SetActive(!hiddenBool);
        CoinCounter.HideCoins(hiddenBool);
        ProblemList.SetActive(!hiddenBool);
    }
}
