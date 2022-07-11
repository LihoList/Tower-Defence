
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 40f;
    public float mouseControllZone = 10f;
    public float scrollSpeed = 5f;

    public float YZoomMin = 10f;
    public float YZoomMax = 80f;

    Vector3 startPosition;
    public float ZClamp = 30;
    public float XClamp = 70;

    int rightBorder = 65;
    int leftBorder = 5;
    int topBorder = 5;
    int bottomBorder = 75;

    private void Start()
    {
        startPosition = transform.position;

        ZClamp = startPosition.z + 30;
    }


    private void Update()
    {
        if(GameManager.isGameOver)
        {
            this.enabled = false;
            return;
        }
    


        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - mouseControllZone) //move camera forward
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= mouseControllZone) // move camera backwards
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - mouseControllZone)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= mouseControllZone)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;

        position.y -= scroll * scrollSpeed * Time.deltaTime * 500;


        position.y = Mathf.Clamp(position.y, YZoomMin, YZoomMax);
        position.z = Mathf.Clamp(position.z, leftBorder, rightBorder);
        position.x = Mathf.Clamp(position.x, topBorder, bottomBorder);

            
        transform.position = position;
    }
}
