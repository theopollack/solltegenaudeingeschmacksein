using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject spawn;
    public float jumppadForce; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LaserButton"))
        {
            DeactivateLaser(
                collision.gameObject.GetComponent<ButtonReference>().GetReference(),
                collision.gameObject
            );
        }

        if (collision.gameObject.CompareTag("Laser"))
        {
            GetComponent<PlayerRespawn>().Die();
        }

        if (collision.gameObject.CompareTag("Jumppad"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumppadForce);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Level Complete!");
        }
    }

    void DeactivateLaser(GameObject laser, GameObject button)
    {
        laser.SetActive(false);
        if (button.TryGetComponent<SpriteRenderer>(out var sr))
        {
            sr.color = Color.green;
        }
        button.transform.position += Vector3.down * 0.15f;
        button.GetComponent<BoxCollider2D>().enabled = false;
    }
}
