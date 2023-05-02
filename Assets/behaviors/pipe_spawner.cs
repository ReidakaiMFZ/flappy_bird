using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pipe_spawner : MonoBehaviour
{
    controles controlesObj;
    // Start is called before the first frame update
    void Start()
    {
        controlesObj = GameObject.Find("bird").gameObject.GetComponent<controles>();
        InvokeRepeating("SpawnPipe", 0, 4);

    }

    // Update is called once per frame
    void Update()
    {
        if (controlesObj.life <= 0)
        {
            CancelInvoke("SpawnPipe");
        }

    }

    void SpawnPipe()
    {
        Debug.Log("spawning");

        // os canos vão de -1.23 a 1,23
        float seed = UnityEngine.Random.Range(0.43f, 1.23f);
        GameObject pipe1 = new GameObject();
        pipe1.AddComponent<pipe_object>();
        pipe_object pipeObj1 = pipe1.GetComponent<pipe_object>();
        pipeObj1.direction = "up";
        pipeObj1.size = seed;
        pipe1.name = "pipe";

        GameObject pipe2 = new GameObject();
        pipe2.AddComponent<pipe_object>();
        pipe_object pipeObj2 = pipe2.GetComponent<pipe_object>();
        pipeObj2.direction = "down";
        pipeObj2.size = -1.66f + seed;
        pipe2.name = "pipe";

        GameObject scorePoint = new GameObject();
        scorePoint.AddComponent<score>();
        scorePoint.name = "score_detector";
    }
    public void Reset()
    {
        InvokeRepeating("SpawnPipe", 0, 4);
    }
}
