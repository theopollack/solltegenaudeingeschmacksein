using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;

    void Start()
    {
        respawnPoint = transform.position;
    }

    public void SetCheckpoint(Vector3 newPoint)
    {
        respawnPoint = newPoint;
    }

    public void Die()
    {
        transform.position = respawnPoint;
    }
}
