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
        StartCoroutine(MoveTo(speed));
        onPlate = true;
    }

    public void GoDown()
    {
        StartCoroutine(MoveTo(speed));
        onPlate = false;
    }

    IEnumerator MoveTo(float moveSpeed)
    {
        if(onPlate)
        {
            while(Mathf.Abs((transform.position.x - targetPos.x)) > 0.1f || Mathf.Abs((transform.position.y - targetPos.y)) > 0.15f)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
                yield return new WaitForSeconds(0.01f);
            }   
        }
        else
        {
            while(Mathf.Abs((transform.position.x - startPos.x)) > 0.1f || Mathf.Abs((transform.position.y - startPos.y)) > 0.2f)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, startPos, step);
                yield return new WaitForSeconds(0.01f);
            }   
        }
        
    }
}
