using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource source1;
    public AudioSource source2;

    void Start()
    {
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            source1.Play();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            source2.Play();
        }
    }
}