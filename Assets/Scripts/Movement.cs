using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float jumpForce = 16f;
    public LayerMask groundLayer;
    public bool isPlayerOne = true;

    public Transform groundCheck;   // empty child at feet
    public float groundCheckRadius = 0.15f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = true;

    float moveInput;
    bool jumpRequest;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // -------- INPUT --------
        moveInput = 0f;

        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1f;
            else if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1f;
        }
        else
        {
            if (Input.GetKey(KeyCode.A)) moveInput = -1f;
            else if (Input.GetKey(KeyCode.D)) moveInput = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            jumpRequest = true;

        // -------- ANIMATION --------
        anim.SetBool("isWalking", moveInput != 0);

        if (moveInput > 0) facingRight = true;
        else if (moveInput < 0) facingRight = false;

        transform.localScale = new Vector3(
            facingRight ? 1.6f : -1.6f,
            1.6f,
            1f
        );
    }

    void FixedUpdate()
    {
        // -------- MOVE --------
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // -------- GROUND CHECK --------
        bool isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        anim.SetBool("isGrounded", isGrounded);

        // -------- JUMP --------
        if (jumpRequest && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        jumpRequest = false;
    }
}
