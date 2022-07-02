using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public static int enemiesAlive;
    public Wave[] waves;

    public GameManager gameManager;
    
    public Transform spawnPoint;
    public Text countdownText;

    public float timeBetweenWaves = 5.5f;
    public float countdoun = 2f;
    int waveNumber = 0;

    private void Start()
    {
        enemiesAlive = 0;
    }

    private void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }

        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdoun <= 0)
        {
            StartCoroutine(SpawnWave());
            countdoun = timeBetweenWaves;
            return;
        }

        countdoun -= Time.deltaTime;
        countdoun = Mathf.Clamp(countdoun, 0f, Mathf.Infinity);
        countdownText.text = string.Format("{0:00.00}", countdoun);


    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveNumber];
        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
