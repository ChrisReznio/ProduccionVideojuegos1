using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource separate;
    public AudioSource swing;
    public AudioSource dash;
    public AudioSource throw1;
    public AudioSource fischl;
    public AudioSource shark;
    public AudioSource victory;


    private GameObject soul;
    private GameObject body;


    void Start()
    {
        soul = GameObject.Find("Soul");
        body = GameObject.Find("Body");
    }

    public void Separate() {
        separate.Play();
    }

    public void Swing() {
        swing.Play();
    }

    public void Dash() {
        dash.Play();
    }

    public void Throw()
    {
        throw1.Play();
    }

    public void Fish()
    {
        fischl.Play();
    }

    public void Shark()
    {
        shark.Play();
    }

    public void Victory()
    {
        victory.Play();
    }
}