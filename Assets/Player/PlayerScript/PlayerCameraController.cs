using Unity.Netcode;
using UnityEngine;

public class PlayerCameraController : NetworkBehaviour
{
    public GameObject cameraPrefab;
    private GameObject myCameraInstance;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;

        myCameraInstance = Instantiate(cameraPrefab);

        // For regular camera
        myCameraInstance.GetComponent<CameraFollowSimple>().SetTarget(transform);
    }
}
