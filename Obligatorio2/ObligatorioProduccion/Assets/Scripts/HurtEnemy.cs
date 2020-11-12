using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public GameObject damageBurstParticles;
    public Transform hitPoint;
    public GameObject damageNumber;

    private GameObject body;
    private GameObject soul;


    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        soul = GameObject.FindGameObjectWithTag("Soul");
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "EnemyHitbox"){
            if (body.GetComponent<BodyController>().isInputEnabled ||
                soul.GetComponent<SoulController>().canDealDamage)
            {
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
                Instantiate(damageBurstParticles, hitPoint.position, hitPoint.rotation);
                var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
            }
        }
    }
}
