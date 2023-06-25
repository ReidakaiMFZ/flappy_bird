using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    private GameObject back;
    private controles life;
    // Start is called before the first frame update
    void Start()
    {
        back = GetComponent<GameObject>();
        life = GameObject.Find("bird").gameObject.GetComponent<controles>();
    }
    void Update()
    {
        if (life.life == 1)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 0.1f);
        }
        else
        {
            transform.Translate(Vector2.zero);
        }
        if (transform.position.x < - 7.69f)
        {
            transform.position = new Vector2(7.614f, transform.position.y);
        }
    }




}
