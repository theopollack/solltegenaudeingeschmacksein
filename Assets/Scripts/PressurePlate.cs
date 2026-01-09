using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Platform Settings")]
    public Platform platform;      // Assign the moving platform in the Inspector
    public bool oneWayUp = false;  // True = platform only goes up, never down

    int playerCount = 0;
    bool pressed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerCount++;

        if (!pressed)
        {
            pressed = true;
            Press();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerCount--;

        if (playerCount <= 0 && pressed && !oneWayUp)
        {
            playerCount = 0;
            pressed = false;
            Release();
        }
    }

    void Press()
    {
        platform.GoUp();
        if (TryGetComponent<SpriteRenderer>(out var sr))
        {
            sr.color = Color.green;
        }
        transform.position += Vector3.down * 0.15f;
    }

    void Release()
    {
        platform.GoDown();
        if (TryGetComponent<SpriteRenderer>(out var sr))
        {
            sr.color = Color.red;
        }
        transform.position += Vector3.up * 0.15f;
    }
}
