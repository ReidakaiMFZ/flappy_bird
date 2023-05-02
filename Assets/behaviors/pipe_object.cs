using System.Collections;
using System.Collections.Generic;
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
        this.transform.localScale = new Vector2(5,7);

        boxCollider = this.gameObject.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        rigidBody = this.gameObject.AddComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;

        SpriteRenderer spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();

        if (direction == "up")
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("pipe_top");
            spriteRenderer.size = new Vector2(5f, 7f);
            boxCollider.size = new Vector2(0.07f, 0.1444f);
            boxCollider.offset = new Vector2(0, 0.0082f);
            spriteRenderer.sortingOrder = 1;
        }
        else if (direction == "down")
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("pipe_top");
            spriteRenderer.flipY = true;
            spriteRenderer.sortingOrder = 1;
            boxCollider.size = new Vector2(0.07f, 0.14673f);
            boxCollider.offset = new Vector2(0, -0.007721379f);
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
