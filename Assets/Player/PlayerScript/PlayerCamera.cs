using Unity.Netcode;
using UnityEngine;
using Unity.Cinemachine;

public class PlayerCamera : NetworkBehaviour
{
    [SerializeField] private CinemachineCamera virtualCamera;
    [SerializeField] private int ownerPriority = 15;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            virtualCamera.gameObject.SetActive(false);
            return;
        }

        if (virtualCamera == null)
        {
            Debug.LogWarning("[PlayerCamera] Missing virtual camera.");
            return;
        }

        // Enable the scene's main camera with CinemachineBrain
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            mainCam.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Main Camera not found in scene.");
        }

        virtualCamera.gameObject.SetActive(true);
        virtualCamera.Priority = ownerPriority;
    }
}
