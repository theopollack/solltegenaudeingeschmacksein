using UnityEngine;

public class WallJumpPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Movement player = other.GetComponent<Movement>();

        if (player != player.isPlayerOne && player != null) {
            player.canWallJump = true;
            Destroy(gameObject);
        }
    }
}

