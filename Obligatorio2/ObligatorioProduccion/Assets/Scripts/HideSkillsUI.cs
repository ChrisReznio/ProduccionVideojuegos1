using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSkillsUI : MonoBehaviour
{
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().isInputEnabled)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(true);
            }
        }
    }
}
