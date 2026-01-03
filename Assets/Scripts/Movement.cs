using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float jumpForce = 16f;

    private Rigidbody2D rb;
    private float moveInput;

    private float jumpPower;
  

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input abfragen (A/D oder Pfeiltasten)
        moveInput = Input.GetAxisRaw("Horizontal");
           
        if (Input.GetButtonDown("Jump"))
        {
            // Springen
            jumpPower = jumpForce;
        }
        else
        {
            jumpPower = 0;
        }
    }

    void FixedUpdate()
    {
        // Rigidbody bewegen
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y + jumpPower);
    }
}
