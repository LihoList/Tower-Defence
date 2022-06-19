using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text countdownText;

    public float timeBetweenWaves = 5.5f;
    public float countdoun = 2f;
    int waveNumber = 0;

    private void Update()
    {
        if (countdoun <= 0)
        {
            StartCoroutine(SpawnWave());

            countdoun = timeBetweenWaves;
        }

        countdoun -= Time.deltaTime;

        countdoun = Mathf.Clamp(countdoun, 0f, Mathf.Infinity);


        countdownText.text = string.Format("{0:00.00}", countdoun);
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        PlayerStats.rounds++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
