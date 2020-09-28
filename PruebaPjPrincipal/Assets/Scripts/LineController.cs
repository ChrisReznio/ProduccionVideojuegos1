using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LineController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject soul;
    private GameObject player;
    private LineRenderer line;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    EdgeCollider2D col;


    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();

        col = gameObject.AddComponent<EdgeCollider2D>();
        col.isTrigger = true;
        col.edgeRadius = 1;

        player = GameObject.FindGameObjectWithTag("Player");
        soul = GameObject.FindGameObjectWithTag("Soul");

        line.startWidth = 0.0f;
        line.endWidth = 0.0f;
        line.material = new Material(Shader.Find("Sprites/Default"));

        line.sortingLayerName = "Player";
        line.sortingOrder = 1;

        line.startColor = line.endColor = new Color(1, 0, 0, 1);
     
        gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.magenta;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        line.colorGradient = gradient;
    }

    // Update is called once per frame
    void Update()
    {
        line.startWidth = 0.0f;
        line.endWidth = 0.0f;

        if (player.GetComponent<PlayerController>().canBeDamaged && soul.GetComponent<SoulController>().IsInputEnabled)
        {
            line.startWidth = 0.1f;
            line.endWidth = 0.1f;
            
            line.SetPosition(0, player.transform.localPosition);
            line.SetPosition(1, soul.transform.localPosition);

            Vector2[] points = new Vector2[2]
            {
                player.transform.localPosition,
                soul.transform.localPosition
            };

            //update the edge colliders points
            col.points = points;
        }

    }
}
