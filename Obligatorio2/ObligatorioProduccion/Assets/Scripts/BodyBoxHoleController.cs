using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBoxHoleController : MonoBehaviour
{
    public Sprite newSprite;
    private string GROUND_LAYER = "Ground";

    void Start() { }

    void Update() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BodyBox")
        {
            transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.active = false;
            FillHole();
        }
    }

    void FillHole()
    {
        SpriteRenderer spriteRenderer = gameObject.transform.parent.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
        spriteRenderer.size = new Vector2(1.2f, 1.2f);
        spriteRenderer.sortingLayerName = GROUND_LAYER;
    }
}
