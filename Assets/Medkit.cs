using UnityEngine;
using System.Collections;

public class Medkit : MonoBehaviour
{
    public float respawnDelay = 10f; // Time before medkit reactivates

    private Collider2D col;
    private SpriteRenderer sprite;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth2D playerHealth = collision.GetComponent<PlayerHealth2D>();
        if (playerHealth != null && playerHealth.IsOwner)
        {
            playerHealth.RequestHealToMaxServerRpc();
            StartCoroutine(RespawnDelay());
        }
        if (playerHealth != null && playerHealth.IsOwner)
        {
            playerHealth.RequestHealToMaxServerRpc();
            Destroy(gameObject);
        }

    }

    private IEnumerator RespawnDelay()
    {
        col.enabled = false;
        sprite.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        col.enabled = true;
        sprite.enabled = true;
    }
}
