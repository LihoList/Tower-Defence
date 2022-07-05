
using UnityEngine;

public class EnemyHpCanvas : MonoBehaviour
{

    Transform mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(mainCamera);
    }
}
