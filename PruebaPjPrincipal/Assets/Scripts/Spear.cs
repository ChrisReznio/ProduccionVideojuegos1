using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidbody2d;

    void Start()
    {
        
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody2d.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

}
