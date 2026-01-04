using UnityEngine;

public class TilemapHazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerRespawn player = other.GetComponent<PlayerRespawn>();
        if (player != null)
        {
            Debug.Log("Player died");
            player.Die();
        }
    }
}
