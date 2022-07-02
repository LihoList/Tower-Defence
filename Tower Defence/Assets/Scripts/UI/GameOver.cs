
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public ScreenFader screenFader;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void RestartButtonClick()
    {
        screenFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MenuButtonClick()
    {
        screenFader.FadeTo(0);
        Time.timeScale = 1;
    }
}
