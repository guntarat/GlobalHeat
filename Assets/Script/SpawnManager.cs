using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private List<Transform> spawnPoints = new List<Transform>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
        }
    }

    public Transform GetRandomSpawnPoint()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogWarning("No spawn points set!");
            return null;
        }

        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }
}
