using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float maxSpeed = 10f;
    public float groundCheckDistance = 0.3f;
    public LayerMask groundLayer;

    public float sprintspeed;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Animator animator;

    private bool facingRight = true; // Pour suivre la direction actuelle

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Animation : mettre à jour le paramètre "speed"
        if (animator != null)
            animator.SetFloat("speed", Mathf.Abs(rb.linearVelocity.x));

        // Détection du sol
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        // Mouvement
        rb.AddForce(new Vector2(moveInput * moveSpeed, 0f), ForceMode2D.Force);

        // Limite de vitesse
        if (Mathf.Abs(rb.linearVelocity.x) > maxSpeed)
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * maxSpeed, rb.linearVelocity.y);
        }

        // Saut
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Descente rapide
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = 5f;
        }
        else
        {
            rb.gravityScale = 1f;
        }

        // 🔄 Retourner le sprite si nécessaire
        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Inverser la direction X
        transform.localScale = scale;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * groundCheckDistance);
    }
}
