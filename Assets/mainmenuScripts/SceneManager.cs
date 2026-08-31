using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void  StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Closegame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
