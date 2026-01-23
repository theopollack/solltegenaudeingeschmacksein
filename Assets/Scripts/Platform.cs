using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    [Header("Movement Settings")]
    public Vector2 targetPos;
    public float speed = 2f;

    Vector2 startPos;
    
    private bool onPlate;


    void Start()
    {
        startPos = transform.position;
    }

    public void GoUp()
    {
        onPlate = true;
    }

    public void GoDown()
    {
        onPlate = false;
    }

    void Update()
    {
        StartCoroutine(MoveTo(speed));
    }

    IEnumerator MoveTo(float moveSpeed)
    {
        if(onPlate)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            yield return new WaitForSeconds(0.01f); 
        }
    
        else
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
