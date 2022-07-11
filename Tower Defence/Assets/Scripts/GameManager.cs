  
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Tutorial (only for the first level")]
    public GameObject tutorial;
    public int firstTime;
    public bool canPlay = false;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public static bool isGameOver;

    public int levelAmount = 1;

    private void Start()
    {
        isGameOver = false;

        if (tutorial != null)
            FirstLaunch();

    }

    void FirstLaunch()
    {
        firstTime = PlayerPrefs.GetInt("firstTime", 1);
        if (firstTime == 0)
        {
            canPlay = true;
            return;
        }
        else
        {
            canPlay = false;
            tutorial.SetActive(true);

        }

    }

    private void Update()
    {
        if (isGameOver)
            return;

        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Invoke("WinWithDelay", 3);
    }

    void WinWithDelay()
    {
        isGameOver = true;
        completeLevelUI.SetActive(true);
    }
}
