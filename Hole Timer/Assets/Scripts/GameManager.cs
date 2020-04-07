using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timer = 10f;
    public Text myTimer;
    public GameObject holeHolder;
    public GameObject panel;
    public GameObject key;
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.transform.position + offset;
        timer -= Time.deltaTime;
        myTimer.text = timer.ToString("0");
        if(timer <= 0)
        {
            panel.SetActive(false);
            key.SetActive(false);
            holeHolder.SetActive(true);
        }
    }
}
