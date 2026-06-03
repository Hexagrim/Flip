using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float jumpSpeed;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    public Transform groundCheck;

    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocityY = jumpSpeed;
        }

        if (rb.linearVelocityY < 0)
        {
            rb.gravityScale = 4f;
        }
        else
        {
            rb.gravityScale = 2f;
        }
        if (isGrounded)
        {
            rb.linearDamping = 1f;
        }
        else
        {
            rb.linearDamping = 0f;
        }

        if(Input.GetKeyUp(KeyCode.Space) && rb.linearVelocityY > 0f)
        {
            rb.linearVelocityY *= 0.55f;
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX = speed;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX = -speed;
        }
        else
        {
            rb.linearVelocityX = 0f;
        }
    }
}
