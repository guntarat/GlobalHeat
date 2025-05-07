using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            Transform spawnPoint = CustomPlayerSpawner.Instance.GetRandomSpawnPoint();
            transform.position = spawnPoint.position;
        }
    }
}
