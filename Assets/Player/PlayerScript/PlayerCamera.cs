using Unity.Netcode;
using UnityEngine;
using Unity.Cinemachine;
using Unity.Collections;

public class PlayerCamera : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private CinemachineCamera virtualCamera;

    [Header("Settings")]
    [SerializeField] private int ownerPriority = 15;

    public NetworkVariable<FixedString32Bytes> PlayerName = new NetworkVariable<FixedString32Bytes>();

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            var server = HostSingleton.Instance?.GameManager?.NetworkServer;
            if (server != null)
            {
                var userData = server.GetUserDataByClientId(OwnerClientId);
                Debug.Log($"[SetName] userName = {userData.userName}");
                PlayerName.Value = userData.userName;
            }
            else
            {
                Debug.LogError("[PlayerCamera] NetworkServer not ready yet!");
            }
        }

        if (IsOwner)
        {
            virtualCamera.Priority = ownerPriority;
        }
    }

}
