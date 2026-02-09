using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleLaser : MonoBehaviour
{
    // Line OF Renderer
    public LineRenderer LineOfSight;

    public int reflections;
    public float MaxRayDistance;
    public LayerMask LayerDetection;
    public float rotationSpeed;
    public GameObject DeactivateObj;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {
        transform.Rotate(rotationSpeed * Vector3.forward * Time.deltaTime);

        LineOfSight.positionCount = 1;
        Vector2 origin = transform.position;
        Vector2 direction = transform.right;

        LineOfSight.SetPosition(0, origin);

        for (int i = 0; i < reflections; i++)
        {
            LineOfSight.positionCount += 1;

            RaycastHit2D hit = Physics2D.Raycast(origin, direction, MaxRayDistance, LayerDetection);

            if (hit.collider != null)
            {
                // place point at hit
                LineOfSight.SetPosition(LineOfSight.positionCount - 1, hit.point);

                // if mirror, reflect and continue from slightly offset point away from the surface
                if (hit.collider.CompareTag("Mirror"))
                {
                    Vector2 reflectDir = Vector2.Reflect(direction, hit.normal).normalized;
                    origin = hit.point + reflectDir * 0.01f; // small offset to avoid hitting the same collider
                    direction = reflectDir;
                    continue;
                }
                else
                {
                    if(hit.collider.CompareTag("LaserReader"))
                    {
                        Debug.Log("karl");
                        DeactivateObj.SetActive(true);
                    }
                    else
                    {
                        DeactivateObj.SetActive(false);
                    }

                    // hit non-mirror object: stop
                    break;
                }
            }
            else
            {
                // no hit: extend to max distance
                LineOfSight.SetPosition(LineOfSight.positionCount - 1, origin + direction * MaxRayDistance);
                break;
            }
        }
    }
}