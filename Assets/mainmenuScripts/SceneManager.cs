using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event uiButtonClick;

    public void  StartGame()
    {
        uiButtonClick.Post(gameObject);
        SceneManager.LoadSceneAsync(1);
    }

    public void Closegame()
    {
        uiButtonClick.Post(gameObject);
        Application.Quit();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        uiButtonClick.Post(gameObject);
        SceneManager.LoadSceneAsync(0);
    }
}
