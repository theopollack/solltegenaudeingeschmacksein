using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float jumpForce = 16f;
    public LayerMask groundLayer;
    public bool isPlayerOne = true;

    private Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float move = 0f;

        // -------- INPUT --------
        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                move = -1f;
            else if (Input.GetKey(KeyCode.RightArrow))
                move = 1f;
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
                move = -1f;
            else if (Input.GetKey(KeyCode.D))
                move = 1f;
        }

        // -------- MOVE --------
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // -------- WALK ANIMATION --------
        bool isWalking = move != 0;
        anim.SetBool("isWalking", isWalking);

        // -------- FLIP --------
        if (move > 0)
            facingRight = true;
        else if (move < 0)
            facingRight = false;

        transform.localScale = new Vector3(
            facingRight ? 1.6f : -1.6f,
            1.6f,
            1f
        );

        // -------- GROUND CHECK --------
        bool isGrounded = Physics2D.OverlapCircle(
            transform.position,
            0.9f,
            groundLayer
        );

        anim.SetBool("isGrounded", isGrounded);

        // -------- JUMP --------
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
