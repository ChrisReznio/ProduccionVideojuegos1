using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damage;
    private float cooldownLeft;
    public float maxCooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldownLeft = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.name == "Player" || other.gameObject.name == "LineRenderer"){
            GameObject theController = GameObject.FindGameObjectWithTag("Player");
            if (theController.GetComponent<PlayerController>().canBeDamaged && cooldownLeft <= 0)
            { 
                other.gameObject.GetComponent<PlayerHealthManager>()
                                .HurtPlayer(damage);
                cooldownLeft = maxCooldown;
            }
        }
        cooldownLeft -= Time.deltaTime;
    }
}
