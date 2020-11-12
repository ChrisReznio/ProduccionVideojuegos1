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
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            FillHole(collision);
        }
    }

    void FillHole(Collider2D collision)
    {
        SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
        spriteRenderer.size = new Vector2(0.54f, 0.42f);
        spriteRenderer.sortingLayerName = GROUND_LAYER;
        Vector3 position = this.transform.parent.transform.position;
        collision.gameObject.transform.position = position;
    }

}
