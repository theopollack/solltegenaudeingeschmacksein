using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Laser;
    public GameObject Button;
    public GameObject Platform;

    public GameObject spawn;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LaserButton"))
        {
            DeactivateLaser(Laser);
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
           StartCoroutine(ActivatePlatform(collision.gameObject));
        }

        if (collision.gameObject.CompareTag("Jumppad"))
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().linearVelocity.x, 20f);
        }

        if(collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Level Complete!");
        }
    }

    void DeactivateLaser(GameObject laser)
    {
        laser.SetActive(false);
        Button.GetComponent<SpriteRenderer>().color = Color.green;
        Button.transform.position = new Vector3(Button.transform.position.x, Button.transform.position.y - 0.15f, Button.transform.position.z);
        Button.GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator ActivatePlatform(GameObject button)
    {
        button.GetComponent<BoxCollider2D>().enabled = false;
        button.GetComponent<SpriteRenderer>().color = Color.green;
        button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - 0.15f, button.transform.position.z);
        Platform.SetActive(true);
        yield return new WaitForSeconds(1f);
        Platform.GetComponent<Platform>().Go();
    }
}
