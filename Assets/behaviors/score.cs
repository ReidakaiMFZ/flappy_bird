using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class score : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;
    controles bird;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector2(2.7f, 0);

        boxCollider = this.gameObject.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        boxCollider.size = new Vector2(0.07f, 2f);
        boxCollider.offset = new Vector2(0, -0.002453208f);

        rigidBody = this.gameObject.AddComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
        this.gameObject.tag = "score";

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
