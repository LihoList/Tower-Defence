
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour
{
    Text waveText;
    WaveManager waveManager;

    private void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        waveText = GetComponent<Text>();

        InvokeRepeating("UpdateText", 0.5f, 0.5f);
    }

    public void UpdateText()
    {
        waveText.text = "Wave " + PlayerStats.rounds.ToString() + "/" + waveManager.waves.Length;
    }
}
