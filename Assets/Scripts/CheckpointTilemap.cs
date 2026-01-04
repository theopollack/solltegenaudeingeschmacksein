using UnityEngine;

public class CheckpointTilemap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerRespawn player = other.GetComponent<PlayerRespawn>();
        if (player != null)
        {
            player.SetCheckpoint(other.transform.position);
            Debug.Log("Checkpoint set");
        }
    }
}
