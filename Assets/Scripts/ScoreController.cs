using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int score;
    public Player peng;
    public Bear bear;
    public GameObject victory;
    public GameObject defeat;


    GameObject[] players;

    // Start is called before the first frame update
    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bear.dead && peng.isDead)
        {
            // Time.timeScale = 0;
            defeat.SetActive(defeat);
        }
        if (score >= 10)
        {
            // Time.timeScale = 0;
            victory.SetActive(defeat);
        }
    }

    public void scoreUp(int value)
    {
        score += value;
    }
}
