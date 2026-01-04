using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float targetY = 10.0f;
    public float speed = 1f;

    void MoveUp(float distance)
    {
        transform.position += new Vector3(0, distance * Time.deltaTime, 0);
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Go()
    {
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        while (transform.position.y < targetY)
        {
            MoveUp(speed);
            yield return null; // Wait for next frame
        }
    }
}
