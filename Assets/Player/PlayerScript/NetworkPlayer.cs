using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            Transform randomSpawn = CustomPlayerSpawner.Instance.GetRandomSpawnPoint();
            transform.position = randomSpawn.position;
        }
    }
}
