using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    [Header("Movement Settings")]
    public float targetY = 10f;
    public float speed = 2f;

    float startY;
    Coroutine routine;

    void Start()
    {
        startY = transform.position.y;
    }

    public void GoUp()
    {
        StartMove(targetY);
    }

    public void GoDown()
    {
        StartMove(startY);
    }

    void StartMove(float y)
    {
        if (routine != null)
            StopCoroutine(routine);

        routine = StartCoroutine(MoveTo(y));
    }

    IEnumerator MoveTo(float y)
    {
        while (!Mathf.Approximately(transform.position.y, y))
        {
            float newY = Mathf.MoveTowards(
                transform.position.y,
                y,
                speed * Time.deltaTime
            );

            transform.position = new Vector3(
                transform.position.x,
                newY,
                transform.position.z
            );

            yield return null;
        }
    }
}
