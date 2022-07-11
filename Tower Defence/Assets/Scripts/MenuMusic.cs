
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private void Awake()
    {
		int numMusic = FindObjectsOfType<MenuMusic>().Length;

		if (numMusic > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

    private void Start()
    {
		InvokeRepeating("Check", 0.5f, 0.5f);
    }

    void Check()
    {
		if (SceneManager.GetActiveScene().buildIndex >= 2)
		{
			Destroy(gameObject);
		}
	}
}
