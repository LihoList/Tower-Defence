using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
    public Image img;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(int sceneToLoad)
    {
        StartCoroutine(FadeOut(sceneToLoad));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0)
        {
            t -= Time.deltaTime;
            img.color = new Color(0f, 0f, 0f, t);

            yield return 0;
        }
    }

    IEnumerator FadeOut(int sceneToLoad)
    {
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime;
            img.color = new Color(0f, 0f, 0f, t);

            yield return 0;
        }


        SceneManager.LoadScene(sceneToLoad);

       
    }
}
