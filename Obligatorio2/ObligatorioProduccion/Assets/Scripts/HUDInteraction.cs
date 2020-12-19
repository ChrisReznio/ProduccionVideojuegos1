using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDInteraction : MonoBehaviour
{
    public static bool canInteract = false;
    void Update()
    {
        var child = transform.GetChild(0).gameObject;
        if (canInteract)
        {
            
            child.SetActive(true);
        }
        else
        {
            child.SetActive(false);
        }
    }
}
