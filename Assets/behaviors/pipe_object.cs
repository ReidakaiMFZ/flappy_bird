using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;


public class pipe_object : MonoBehaviour
{
    public string direction;
    public float size;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    controles bird;

    void Start()
    {
        this.gameObject.tag = "wall-dmg";
        this.transform.position = new Vector2(2.5f ,size);
        this.transform.localScale = new Vector2(0.13077f, 0.18f);

        boxCollider = this.gameObject.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        rigidBody = this.gameObject.AddComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;

        SpriteRenderer spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();

        if (direction == "up")
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("pipe_clipart");
            spriteRenderer.size = new Vector2(5f, 7f);
            spriteRenderer.flipY = true;
            boxCollider.size = new Vector2(2.960218f, 5.836285f);
            boxCollider.offset = new Vector2(-0.03080362f, -0.01540184f);
            spriteRenderer.sortingOrder = 1;
        }
        else if (direction == "down")
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("pipe_clipart");
            spriteRenderer.flipY = false;
            spriteRenderer.sortingOrder = 1;
            boxCollider.size = new Vector2(2.960218f, 5.836285f);
            boxCollider.offset = new Vector2(-0.03080362f, -0.01540184f);
        }
        bird = GameObject.Find("bird").gameObject.GetComponent<controles>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.life == 1)
        {
            rigidBody.velocity = new Vector2(-0.5f, 0);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collision");
        if (collider.gameObject.tag == "endline")
        {
            // destroy this object 
            Destroy(this.gameObject);
        }
    }
}
