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

    public bool isFlipped = false;
    int gravityMult = 1;

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
            rb.linearVelocityY = jumpSpeed * gravityMult;
        }
        if (isFlipped)
        {
            if (rb.linearVelocityY > 0)
            {
                rb.gravityScale = -4f;
            }
            else
            {
                rb.gravityScale = -2f;
            }
        }
        else
        {
            if (rb.linearVelocityY < 0)
            {
                rb.gravityScale = 4f;
            }
            else
            {
                rb.gravityScale = 2f;
            }
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


        if (Input.GetKeyDown(KeyCode.Q) && isGrounded)
        {
            isFlipped = !isFlipped;
            gravityMult = (isFlipped ? -1 : 1);
            rb.linearVelocityY = -gravityMult * 10f;
        }
        transform.localScale = new Vector2(transform.localScale.x, gravityMult);
        //this is it i g

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
