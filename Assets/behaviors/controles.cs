using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class controles : MonoBehaviour
{
    private Rigidbody2D character;
    private float jump = 2f;
    private float gravity = 2f;
    public int life = 1;

    void Start() 
    {
        character = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("bird2");

            Invoke("UpdateSprite", 0.3f);

        }
        if (life < 1)
        {
            gravity = 0;
            character.velocity = Vector2.zero;
            jump = 0;

        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "wall-dmg")
        {
            life--;
            Button button = GameObject.Find("Button").GetComponent<Button>();
            button.interactable = true;
        }
        else if(collider.gameObject.tag == "wall")
        {
            character.Sleep();
            character.WakeUp();
        }
        else if (collider.gameObject.tag == "score")
        {
            UnityEngine.UI.Text score = GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>();
            score.text = (int.Parse(score.text) + 1).ToString();
        }

    }
    private void FixedUpdate()
    {
        character.AddForce(Vector2.down * gravity, ForceMode2D.Force);
    }

    void UpdateSprite()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("bird1");
    }
    public void Reset()
    {
        life = 1;
        transform.position = new Vector2(-1.8f, 0);
        jump = 2f;
        gravity = 2f;
    }
}
