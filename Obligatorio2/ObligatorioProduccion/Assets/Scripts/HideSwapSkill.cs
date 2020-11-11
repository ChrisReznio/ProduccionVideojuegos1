using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSwapSkill : MonoBehaviour
{
    void Update()
    {
        var child = transform.GetChild(0).gameObject;
        if (GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().canBeDamaged)
        {
            child.SetActive(true);
        }
        else
        {
            child.SetActive(false);
        }
    }
}
