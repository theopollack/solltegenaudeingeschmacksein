using UnityEngine;

public class SceneFade : MonoBehaviour
{
    public SpriteRenderer obj;
    public float fadeSpeed = 1f; // Alpha change per second

    void Start()
    {
        obj.gameObject.SetActive(true);
    }

    void Update()
    {
        Color color = obj.color;
        if (color.a > 0f)
        {
            color.a -= fadeSpeed * Time.deltaTime;
            color.a = Mathf.Clamp01(color.a); // Ensure alpha stays between 0 and 1
            obj.color = color;

            if (color.a < 0.8f)
            {
                fadeSpeed = 0.5f;
            }
        }
    }
}
