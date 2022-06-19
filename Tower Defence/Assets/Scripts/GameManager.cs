  
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static bool isGameOver;

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
}
