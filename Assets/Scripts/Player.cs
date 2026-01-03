using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Laser;
    public GameObject Button;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            DeactivateLaser(Laser);
        }

        if (collision.gameObject.CompareTag("Jumppad"))
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().linearVelocity.x, 20f);
        }
    }

    void DeactivateLaser(GameObject laser)
    {
        laser.SetActive(false);
        Button.GetComponent<SpriteRenderer>().color = Color.green;
        Button.transform.position = new Vector3(Button.transform.position.x, Button.transform.position.y - 0.1f, Button.transform.position.z);
        Button.GetComponent<BoxCollider2D>().enabled = false;
    }
}
