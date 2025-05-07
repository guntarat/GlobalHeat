using Unity.Netcode;
using UnityEngine;

public class PlayerFlip2D : NetworkBehaviour
{
    private Camera mainCam;

    void Update()
    {
        if (mainCam == null || !mainCam.enabled)
        {
            mainCam = FindActiveCamera();
        }

        if (mainCam == null) return;

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

    private Camera FindActiveCamera()
    {
        Camera[] allCams = Camera.allCameras;
        foreach (Camera cam in allCams)
        {
            if (cam.enabled) return cam;
        }
        return null;
    }
}
