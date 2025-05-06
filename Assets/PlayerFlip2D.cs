using UnityEngine;

public class PlayerFlip2D : MonoBehaviour
{
    private Camera mainCam;

    void Start()
{
    mainCam = Camera.main;

    if (mainCam == null)
    {
        // Fallback: find any camera in the scene
        mainCam = FindObjectOfType<Camera>();
        if (mainCam == null)
        {
            Debug.LogError("No camera found! Make sure a camera is active and tagged.");
        }
    }
}


    void Update()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < transform.position.x)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }
        else
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}
