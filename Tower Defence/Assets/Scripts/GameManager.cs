  
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public static bool isGameOver;

    public int levelAmount = 1;

    private void Start()
    {
        isGameOver = false;
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
