using Unity.Netcode;
using UnityEngine;

public class PlayerHealth2D : NetworkBehaviour
{
    
    public int maxHealth = 100;
    private NetworkVariable<int> currentHealth = new NetworkVariable<int>();

    private Rigidbody2D rb;
    private bool isDead = false;

    public float knockbackForce = 7f;
    public float respawnDelay = 2f;
    public Transform respawnPoint;

    void Start()
{
    rb = GetComponent<Rigidbody2D>();

    if (IsServer)
    {
        currentHealth.Value = maxHealth;
    }
}

    public void TakeDamage(int amount, Vector2 knockbackDirection)
    {
        if (!IsServer || isDead) return;

        currentHealth.Value -= amount;

        // Knockback
        rb.velocity = Vector2.zero;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        if (currentHealth.Value <= 0)
        {
            isDead = true;
            StartCoroutine(HandleDeath());
        }
    }

    private System.Collections.IEnumerator HandleDeath()
    {
        DisablePlayerClientRpc();

        GetComponentInChildren<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        currentHealth.Value = maxHealth;
        Transform randomSpawn = SpawnManager.Instance.GetRandomSpawnPoint();
        transform.position = randomSpawn ? randomSpawn.position : Vector3.zero;


        GetComponentInChildren<SpriteRenderer>().enabled = true;

        EnablePlayerClientRpc();
        isDead = false;
    }

    [ClientRpc]
    void DisablePlayerClientRpc()
    {
        if (IsOwner)
            GetComponent<PlayerMovement2D>().enabled = false;
    }

    [ClientRpc]
    void EnablePlayerClientRpc()
    {
        if (IsOwner)
            GetComponent<PlayerMovement2D>().enabled = true;
    }

    public int GetCurrentHealth() => currentHealth.Value;

}
