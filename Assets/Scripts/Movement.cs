using UnityEngine;

public class Movement : MonoBehaviour
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
    public Transform[] wallChecker;

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
        bool isWalking = anim.GetBool("isWalking");

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
        // -------- GROUND CHECK --------
        bool isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
        anim.SetBool("isGrounded", isGrounded);

        // -------- MOVE --------
        float targetVelocityX = moveInput * speed;

        if (isGrounded)
        {
            // Apply friction when grounded
            float friction = 0.7f; // 0 = stop instantly, 1 = no friction (adjust to taste)
            float newVelocityX = Mathf.Lerp(rb.linearVelocity.x, targetVelocityX, friction);
            rb.linearVelocity = new Vector2(newVelocityX, rb.linearVelocity.y);
        }
        else
        {
            // In air, move directly (no friction)
            rb.linearVelocity = new Vector2(targetVelocityX, rb.linearVelocity.y);
        }

        // -------- JUMP --------
        if (jumpRequest && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        jumpRequest = false;
    }

}
