
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameManager gameManager;


    [Header("Tutorial slides")]
    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;

    private void Start()
    {
        slide1.SetActive(true);
        slide2.SetActive(false);
        slide3.SetActive(false);
    }

    public void FirstButtonClick() // first silde 
    {
        slide1.SetActive(false);
        slide2.SetActive(true);
        slide3.SetActive(false);
    }

    public void SecondButtonClick() //second slide
    {
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(true);
    }

    public void ThirdButtonClick() //third slide
    {
        slide1.SetActive(false);
        slide2.SetActive(false);
        slide3.SetActive(false);

        gameObject.SetActive(false);

        gameManager.canPlay = true;
        PlayerPrefs.SetInt("firstTime", 0);
    }

    public void Back_2_ButtonClick()
    {
        slide1.SetActive(true);
        slide2.SetActive(false);
        slide3.SetActive(false);
    }

    public void Back_3_ButtonClick()
    {
        slide1.SetActive(false);
        slide2.SetActive(true);
        slide3.SetActive(false);
    }

}
