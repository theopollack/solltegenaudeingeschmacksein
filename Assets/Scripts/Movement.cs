using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float jumpForce = 16f;

    private Rigidbody2D rb;
    private float moveInput;

    public LayerMask groundLayer;

    public bool isPlayerOne = true;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input abfragen (A/D oder Pfeiltasten)
        //moveInput = Input.GetAxisRaw("Horizontal");
        //Debug.Log("move Input: " + moveInput);

        if (isPlayerOne)
        {
            if (Input.GetKey("left"))
            {
                rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            }

            if (Input.GetKey("right"))
            {
                rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            }
            else if (!Input.GetKey("left") && !Input.GetKey("right"))
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }
        else
        {
            if (Input.GetKey("a"))
            {
                rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            }

            if (Input.GetKey("d"))
            {
                rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            }
            else if (!Input.GetKey("a") && !Input.GetKey("d"))
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }

        bool isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, 0.9f, groundLayer);
        Debug.Log("Is Grounded: " + isGrounded);

        // Springen
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Rigidbody bewegen
        //rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
}
