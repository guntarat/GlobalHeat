using UnityEngine;
using Unity.Netcode;

public class CustomPlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    
    private void Start()
{
    if (NetworkManager.Singleton != null)
    {
        NetworkManager.Singleton.AddNetworkPrefab(playerPrefab);
        Debug.Log("Registered player prefab via AddNetworkPrefab");
        NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
    }
    else
    {
        Debug.LogError("NetworkManager.Singleton is null in Start. Ensure NetworkManager is in the scene and enabled.");
    }
}


    private void HandleClientConnected(ulong clientId)
    {
        if (!NetworkManager.Singleton.IsServer) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        var netObj = player.GetComponent<NetworkObject>();
        netObj.SpawnAsPlayerObject(clientId);

        Debug.Log($"[Server] Spawned player for clientId: {clientId} | OwnerClientId: {netObj.OwnerClientId}");
    }
}
