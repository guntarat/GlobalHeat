using Unity.Netcode;
using UnityEngine;

public class PlayerFlip2D : NetworkBehaviour
{
    private Camera mainCam;
    private bool facingRight = true;

    void Update()
    {
        if (!IsOwner) return;

        if (mainCam == null || !mainCam.enabled)
        {
            mainCam = FindActiveCamera();
        }

        if (mainCam == null) return;

        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < transform.position.x && facingRight)
        {
            Flip();
        }
        else if (mousePos.x > transform.position.x && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
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
