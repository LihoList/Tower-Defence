
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [Header("Time Scale Button")]
    public Image image;
    bool timeScalePressed = false;
    bool pausePressed = false;

    [Header("Pause Button")]
    public Image pauseImage;

    [Header("Menu Button")]
    public GameObject pauseMenu;

    private void Start()
    {
        image.color = Color.white;
        pauseImage.color = Color.white;
    }

    public void TimeScaleButtonClick()
    {
        if(!timeScalePressed)
        {
            Time.timeScale = 2f;
            timeScalePressed = !timeScalePressed;
            image.color = Color.yellow;
        }
        else
        {
            Time.timeScale = 1f;
            timeScalePressed = !timeScalePressed;
            image.color = Color.white;
        }

        pauseImage.color = Color.white;
    }

    public void PauseButtonClick()
    {
        if (!pausePressed)
        {
            Time.timeScale = 0f;
            pausePressed = !pausePressed;
            pauseImage.color = Color.yellow;
        }
        else
        {

            if(timeScalePressed)
            {
                Time.timeScale = 2f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            pausePressed = !pausePressed;
            pauseImage.color = Color.white;
        }
    }

    public void MenuButtonClick()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    
}
