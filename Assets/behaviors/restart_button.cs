using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restart_button : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        controles bird = GameObject.Find("bird").GetComponent<controles>();
        pipe_spawner spawner = GameObject.Find("pipe_creator").GetComponent<pipe_spawner>();
        bird.Reset();
        spawner.Reset();
        pipe_object[] pipes = GameObject.FindObjectsOfType<pipe_object>();
        foreach (pipe_object pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
        score[] scores = GameObject.FindObjectsOfType<score>();
        foreach (score score in scores)
        {
            Destroy (score.gameObject);
        }
        UnityEngine.UI.Text textScore = GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>();
        textScore.text = "0";
        button.interactable = false;

    }
}
