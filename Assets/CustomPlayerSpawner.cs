using UnityEngine;

public class CustomPlayerSpawner : MonoBehaviour
{
    public static CustomPlayerSpawner Instance { get; private set; }
    public Transform[] spawnPoints;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
