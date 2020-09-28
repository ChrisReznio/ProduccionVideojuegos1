﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public GameObject damageBurstParticles;
    public Transform hitPoint;
    public GameObject damageNumber;

    private GameObject player;
    private GameObject soul;

    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        soul = GameObject.FindGameObjectWithTag("Soul");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            if (player.GetComponent<PlayerController>().isInputEnabled ||
                soul.GetComponent<SoulController>().canDealDamage)
            {
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
                Instantiate(damageBurstParticles, hitPoint.position, hitPoint.rotation);
                var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
                Debug.Log(damageToGive.ToString());
                Debug.Log(clone.ToString());
                clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
            }
        }
    }
}