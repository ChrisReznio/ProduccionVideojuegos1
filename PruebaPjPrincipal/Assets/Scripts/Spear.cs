using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidbody2d;

    public float range;
    private float distanceTraveled;

    void Start()
    {
        distanceTraveled = 0;
    }

    void Update() 
    {
        distanceTraveled += speed * Time.deltaTime; 
        if(distanceTraveled >= range){
            Destroy(gameObject);
        }
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody2d.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

}
