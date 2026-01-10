using UnityEngine;

public class Mirror : MonoBehaviour
{
    private bool go;

    void Start()
    {
        go = false;
    }

    public void Spin()
    {
        go = true;
    }

    public void NoSpin()
    {
        go = false;
    }

    void Update()
    {
        if(go)
        {
            transform.Rotate(30f * Vector3.forward * Time.deltaTime);
        }
    }
}
