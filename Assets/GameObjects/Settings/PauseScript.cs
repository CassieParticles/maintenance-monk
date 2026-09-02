using GameObjects.Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    GameObject PauseCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseCanvas = transform.GetChild(0).gameObject;
        PauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    public void Pause() {
        PlayerData.Instance.TogglePause();
        PauseCanvas.SetActive(PlayerData.Instance.IsPaused);
        PauseCanvas.transform.GetChild(1).GetComponent<Button>().Select();
        if (PlayerData.Instance.IsPaused ) {
            Time.timeScale = 0.0f;
        } else {
            Time.timeScale = 1.0f;
        }
    }
}
