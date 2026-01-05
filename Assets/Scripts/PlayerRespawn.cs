using System.Collections;
using System.Collections.Generic;
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
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject Player in Players)
        {
            Player.transform.position = respawnPoint;
        }
    }
}
