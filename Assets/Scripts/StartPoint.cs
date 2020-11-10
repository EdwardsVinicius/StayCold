using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class StartPoint: MonoBehaviour
{
    public Transform startPoint;

    public GameObject[] multiplayer;
    public GameObject singleplayer;


    public static bool isMultiplayer = true;
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
        {
            Instantiate(singleplayer, startPoint);
        }
    }

    public void Reset()
    {
        singleplayer.transform.position = startPoint.position;
    }

}