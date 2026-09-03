using GameObjects.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{

    TextMeshProUGUI CoinText;
    GameObject CoinImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CoinImage = transform.GetComponentInChildren<Image>().gameObject;
        CoinText = transform.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = PlayerData.Instance.Coins.ToString();
    }

    public void HideCoins(bool hidden) {
        CoinImage.SetActive(!hidden);
        CoinText.gameObject.SetActive(!hidden);
    }
}
