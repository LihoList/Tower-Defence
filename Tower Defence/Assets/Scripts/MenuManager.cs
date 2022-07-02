
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public ScreenFader screenFader;

    public void PlayButtonClick()
    {
        screenFader.FadeTo(1);
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
