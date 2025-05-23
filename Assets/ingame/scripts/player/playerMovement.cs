using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float maxSpeed = 10f;
    public float groundCheckDistance = 0.3f;
    public LayerMask groundLayer;
    public float sprintSpeed;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Animator animator;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    private bool isFalling;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Ground checks
        bool leftGrounded = groundCheckLeft && Physics2D.Raycast(groundCheckLeft.position, Vector2.down, groundCheckDistance, groundLayer);
        bool rightGrounded = groundCheckRight && Physics2D.Raycast(groundCheckRight.position, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = leftGrounded || rightGrounded;

        // Saut
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Gravité rapide
        rb.gravityScale = (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? 5f : 1f;

        // Déplacement horizontal direct
        float targetSpeed = moveInput * moveSpeed;
        rb.linearVelocity = new Vector2(targetSpeed, rb.linearVelocity.y);

        // Limiter vitesse max (optionnel ici, car on fixe déjà la vitesse)
        rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocity.x, -maxSpeed, maxSpeed), rb.linearVelocity.y);

        // Animations
        if (animator != null)
        {
            animator.SetFloat("speed", Mathf.Abs(rb.linearVelocity.x));
            animator.SetBool("isGrounded", isGrounded);
        }

        // États saut / chute
        isJumping = !isGrounded && rb.linearVelocity.y > 0.1f;
        isFalling = !isGrounded && rb.linearVelocity.y < -0.1f;

        if (animator != null)
        {
            animator.SetBool("isJumping", isJumping);
            animator.SetBool("isFalling", isFalling);
        }

        // Flip sprite
        if (moveInput > 0 && !facingRight) Flip();
        else if (moveInput < 0 && facingRight) Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnDrawGizmos()
    {
        if (groundCheckLeft != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(groundCheckLeft.position, Vector2.down * groundCheckDistance);
        }
        if (groundCheckRight != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(groundCheckRight.position, Vector2.down * groundCheckDistance);
        }
    }
}
