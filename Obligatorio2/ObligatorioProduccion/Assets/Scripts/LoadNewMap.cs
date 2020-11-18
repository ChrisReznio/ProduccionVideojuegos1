using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewMap : MonoBehaviour
{
    public string levelToLoad;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Body")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
