using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 12f;
    private float speed;
    public float jumpForce = 16f;
    public LayerMask groundLayer;
    public bool isPlayerOne = true;

    public Transform groundCheck;  
    public float groundCheckRadius = 0.15f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = true;
    public Transform[] wallChecker;

    public bool wallJumpActive;
    private GameObject currentWallChecker;
    public bool onWall
    {
        get
        {
            foreach (Transform checker in wallChecker)
            {
                Collider2D hit = Physics2D.OverlapCircle(
                    checker.position,
                    0.1f,
                    groundLayer
                );
                if (hit != null)
                {
                    currentWallChecker = checker.gameObject;
                    return true;
                }
            }
            return false;
        }
    }

    private bool justWallJumped;

    float moveInput;
    bool jumpRequest;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = Speed;
    }

    void Update()
    {
        // -------- INPUT --------
        if (!justWallJumped) {
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
        }
        /*else {
        if (isPlayerOne)
            {
                if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1f;
                else if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1f;
            }
            else
            {
                if (Input.GetKey(KeyCode.A)) moveInput = -0.5f;
                else if (Input.GetKey(KeyCode.D)) moveInput = 0.5f;
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
            jumpRequest = true;
        

        // -------- ANIMATION --------
        anim.SetBool("isWalking", moveInput != 0);
        bool isWalking = anim.GetBool("isWalking");
        if(!isWalking)
        {
            anim.Play("New State");
        }


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
            speed = Speed;
            justWallJumped = false;
        }
        else
        {
            // In air, move directly (no friction)
            rb.linearVelocity = new Vector2(targetVelocityX, rb.linearVelocity.y);
        }

        // -------- JUMP --------
        if (jumpRequest && isGrounded || onWall && !isPlayerOne && jumpRequest && !isGrounded)
        {
            speed = Speed;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);


            if(onWall && !isPlayerOne && jumpRequest && !isGrounded)
            {
                justWallJumped = true;
                if (currentWallChecker.transform.position.x > transform.position.x)
                {
                    // Wall is on the right side - push left
                    moveInput = -1.4f;
                    speed *= 0.5f;
                    rb.linearVelocity = new Vector2(0, jumpForce);
                    facingRight = false;
                }
                else
                {
                    // Wall is on the left side - push right
                    moveInput = 1.4f;
                    speed *= 0.5f;
                    rb.linearVelocity = new Vector2(0, jumpForce);
                    facingRight = true;
                }
                transform.localScale = new Vector3(
                    facingRight ? 1.6f : -1.6f,
                    1.6f,
                    1f
                );
            }
        }

        jumpRequest = false;
    }

}
