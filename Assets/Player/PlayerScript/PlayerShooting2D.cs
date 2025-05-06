using Unity.Netcode;
using UnityEngine;

public class PlayerShooting2D : NetworkBehaviour
{
    public GameObject bulletTrailPrefab;
    public Transform firePoint;     // Where the raycast starts
    public float fireDistance = 10f;
    public LayerMask hitLayers;

    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetButtonDown("Fire1"))
        {
            ShootServerRpc();
        }
    }

    [ServerRpc]
void ShootServerRpc()
{
    Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
    Vector2 origin = firePoint.position;

    RaycastHit2D hit = Physics2D.Raycast(origin, direction, fireDistance, hitLayers);

    Vector2 endPoint = origin + direction * fireDistance;
    if (hit.collider != null)
    {
        endPoint = hit.point;

        PlayerHealth2D health = hit.collider.GetComponent<PlayerHealth2D>();
if (health != null)
{
    Vector2 knockDir = (hit.collider.transform.position - transform.position).normalized;
    health.TakeDamage(10, knockDir);
}

    }

    SpawnTrailClientRpc(origin, endPoint);
}
[ClientRpc]
void SpawnTrailClientRpc(Vector2 start, Vector2 end)
{
    GameObject trail = Instantiate(bulletTrailPrefab);
    LineRenderer lr = trail.GetComponent<LineRenderer>();
    lr.SetPosition(0, start);
    lr.SetPosition(1, end);
    Destroy(trail, 0.1f);
}

}
