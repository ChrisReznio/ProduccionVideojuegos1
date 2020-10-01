using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private GameObject soul;
    private GameObject body;
    private LineRenderer line;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;


    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();

        body = GameObject.FindGameObjectWithTag("Body");
        soul = GameObject.FindGameObjectWithTag("Soul");

        line.startWidth = 0.0f;
        line.endWidth = 0.0f;
        line.material = new Material(Shader.Find("Sprites/Default"));

        line.sortingLayerName = "Body";
        line.sortingOrder = 1;

        line.startColor = line.endColor = new Color(1, 0, 0, 1);
     
        gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.cyan;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.black;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 1.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        line.colorGradient = gradient;
    }
    

    void Update()
    {
        line.startWidth = 0.0f;
        line.endWidth = 0.0f;

        if (body.GetComponent<BodyController>().canBeDamaged && soul.GetComponent<SoulController>().IsInputEnabled)
        {
            line.startWidth = 0.1f;
            line.endWidth = 0.2f;
            
            line.SetPosition(0, body.transform.localPosition);
            line.SetPosition(1, soul.transform.localPosition);
        }

    }
}
