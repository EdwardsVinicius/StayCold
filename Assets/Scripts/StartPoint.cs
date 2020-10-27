using UnityEngine;
using System.Collections;

public class StartPoint: MonoBehaviour
{
    public Transform startPoint;

    public GameObject[] multiplayer;
    public GameObject singleplayer;

    public bool isMultiplayer = false;
    void Awake()
    {
        if (isMultiplayer)
        {
            foreach(GameObject g in multiplayer)
            {
                Instantiate(g, startPoint);
            }

        }
        else
            Instantiate(singleplayer, startPoint);
    }


    public void Reset()
    {
        singleplayer.transform.position = startPoint.position;
    }
}