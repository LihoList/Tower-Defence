
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public ScreenFader screenFader;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void MenuButtonClick()
    {
        screenFader.FadeTo(0);
        Toggle();
    }

    public void RestartButtonClick()
    {
        screenFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
        Toggle();
    }
}
