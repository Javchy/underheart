using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 7f;
    public float maxSpeed = 10f; 
    public float groundCheckDistance = 0.3f; // Distance du raycast pour vérifier si le joueur est au sol
    public LayerMask groundLayer; // Couche des sols (pour vérifier si le joueur est au sol)


    public float sprintspeed;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        
        float moveInput = Input.GetAxis("Horizontal"); 
        rb.AddForce(new Vector2(moveInput * moveSpeed, 0f), ForceMode2D.Force);

        
        if (Mathf.Abs(rb.linearVelocity.x) > maxSpeed)
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * maxSpeed, rb.linearVelocity.y);
        }

        
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

       
        if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = 5f;
        }
 
        else
        {
            rb.gravityScale = 1f; 
        }
    }

    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * groundCheckDistance);
    }
}

