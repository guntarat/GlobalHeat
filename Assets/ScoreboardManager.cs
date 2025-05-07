using UnityEngine;
using Unity.Netcode;
using System.Collections.Generic;

public class ScoreboardManager : MonoBehaviour
{
    public GameObject scoreboardEntryPrefab;
    public Transform entryParent;

    private Dictionary<ulong, ScoreboardEntry> entries = new();

    private void Start()
    {
        if (NetworkManager.Singleton.IsServer)
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
    }

    private void OnClientConnected(ulong clientId)
    {
        Invoke(nameof(RefreshPlayers), 0.5f); // Delay to ensure objects are spawned
    }

    private void RefreshPlayers()
    {
        foreach (var netObj in NetworkManager.Singleton.SpawnManager.SpawnedObjectsList)
        {
            if (netObj == null) continue;

            PlayerStats stats = netObj.GetComponent<PlayerStats>();
            if (stats == null) continue;

            if (!entries.ContainsKey(stats.OwnerClientId))
            {
                GameObject entryGO = Instantiate(scoreboardEntryPrefab, entryParent);
                ScoreboardEntry entry = entryGO.GetComponent<ScoreboardEntry>();
                entry.Initialize(stats);
                entries.Add(stats.OwnerClientId, entry);
            }
        }
    }
}
