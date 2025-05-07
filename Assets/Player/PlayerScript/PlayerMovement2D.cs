using Unity.Netcode;
using UnityEngine;

public class PlayerMovement2D : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource jumpAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log($"{gameObject.name} | IsOwner: {IsOwner} | IsLocalPlayer: {IsLocalPlayer} | IsServer: {IsServer}");
    }

    void Update()
    {
        if (!IsOwner) return;

        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            if (jumpAudio != null)
                jumpAudio.Play();
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
    public override void OnNetworkSpawn()
{
    if (!IsOwner) return;

    Debug.Log("[Camera] Setting target for local player");

    var camFollow = Camera.main?.GetComponent<CameraFollowSimple>();
    if (camFollow != null)
    {
        camFollow.SetTarget(transform);
    }
    else
    {
        Debug.LogWarning("CameraFollowSimple not found on MainCamera.");
    }
}
}
