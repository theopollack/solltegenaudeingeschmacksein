using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float jumpForce = 16f;

    private Rigidbody2D rb;
    private float moveInput;

    public LayerMask groundLayer;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input abfragen (A/D oder Pfeiltasten)
        moveInput = Input.GetAxisRaw("Horizontal");

        bool isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, 1f, groundLayer);
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
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
}
