using UnityEngine;

public class FollowPlayers : MonoBehaviour
{
    public Transform squareA;
    public Transform squareB;

    void Update()
    {
        Vector2 posA = squareA.position;
        Vector2 posB = squareB.position;

        Vector2 middle = (posA + posB) / 2f;
        transform.position = middle;
    }
}