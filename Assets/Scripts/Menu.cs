using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator anim;
    public GameObject spacetext;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(NewScene());
        }
    }

    IEnumerator NewScene()
    {
        anim.Play("menu");
        spacetext.SetActive(false);
        yield return new WaitForSeconds(5/3f);
        SceneManager.LoadScene("Level 3 neu");
    }
}
