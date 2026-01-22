using UnityEngine;

public class PressureLaser : MonoBehaviour
{
    public GameObject Mirror;
    
    bool pressed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (!pressed)
        {
            pressed = true;
            Press();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;


        if (pressed)
        {
            pressed = false;
            Release();
        }
    }

    void Press()
    {
        if (TryGetComponent<SpriteRenderer>(out var sr))
        {
            sr.color = Color.green;
            Mirror.GetComponent<Mirror>().Spin();
        }
    }

    void Release()
    {
        if (TryGetComponent<SpriteRenderer>(out var sr))
        {
            sr.color = Color.red;
            Mirror.GetComponent<Mirror>().NoSpin();
        }
    }
}
