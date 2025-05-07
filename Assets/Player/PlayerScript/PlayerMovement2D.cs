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
    
    Animator animator;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        Debug.Log($"{gameObject.name} | IsOwner: {IsOwner} | IsLocalPlayer: {IsLocalPlayer} | IsServer: {IsServer}");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!IsOwner) return;

        animator.SetBool("IsJump", false);
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        Debug.Log("Speed: " + Mathf.Abs(rb.velocity.x));
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetBool("IsJump", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            if (jumpAudio != null)
                jumpAudio.Play();
        }
        
        
      
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
