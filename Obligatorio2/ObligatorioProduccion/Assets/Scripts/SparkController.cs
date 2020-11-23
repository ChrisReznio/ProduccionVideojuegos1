using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{
    public void FinishAttack()
    {
        transform.gameObject.SetActive(false);
    }
}
