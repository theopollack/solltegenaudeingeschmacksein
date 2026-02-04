using UnityEngine;

public class WallJumpPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Movement player = other.GetComponent<Movement>();

        if (player != null  && !player.isPlayerOne) {
            player.canWallJump = true;
            Destroy(gameObject);
        }
    }
}

