
using UnityEngine;

public class LevelWon : MonoBehaviour
{
    public ScreenFader screenFader;
    public int nextLevelNumber = 2;

    public GameManager gameManager;

    public void MenuButtonClick()
    {
        screenFader.FadeTo(1);
    }

    public void Continue()
    {
        if(nextLevelNumber > gameManager.levelAmount)
        {
            screenFader.FadeTo(1);
        }
        else
        {
            screenFader.FadeTo(nextLevelNumber + 1);
            PlayerPrefs.SetInt("levelReached", nextLevelNumber);
        }

        
    }
}
