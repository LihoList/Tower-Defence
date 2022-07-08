
using UnityEngine;

public class LevelWon : MonoBehaviour
{
    public ScreenFader screenFader;
    public int nextLevelNumber = 2;

    public GameManager gameManager;

    private void OnEnable()
    {
        PlayerPrefs.SetInt("levelReached", nextLevelNumber);

        Debug.Log("New level unclocked");
    }

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
            
        }

        
    }
}
