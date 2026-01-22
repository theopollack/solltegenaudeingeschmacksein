using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerRespawn>().respawnPoint = transform.position;
            activated = true;

            // optional: prevent retriggering
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
