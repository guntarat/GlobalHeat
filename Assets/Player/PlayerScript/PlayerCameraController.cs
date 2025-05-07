using Unity.Netcode;
using UnityEngine;

public class PlayerCameraController : NetworkBehaviour
{
    public GameObject cameraPrefab;
    private GameObject myCameraInstance;
    void Awake()
{
    Debug.Log("[PlayerCameraController] Awake");
}

void Start()
{
    Debug.Log($"[PlayerCameraController] Start | IsOwner: {IsOwner}");
}

    public override void OnNetworkSpawn()
{
    Debug.Log($"[PlayerCameraController] OnNetworkSpawn | IsOwner: {IsOwner}");
    if (!IsOwner) return;

    myCameraInstance = Instantiate(cameraPrefab);

    // Ensure it's tagged as MainCamera
    Camera cam = myCameraInstance.GetComponent<Camera>();
    if (cam != null)
    {
        cam.tag = "MainCamera";
    }

    myCameraInstance.GetComponent<CameraFollowSimple>().SetTarget(transform);
}
}
