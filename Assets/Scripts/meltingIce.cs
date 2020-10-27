using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meltingIce : MonoBehaviour
{
    public float timer = 0f;
    public float limitTimer = 5f;

    public GameObject gameObject;
    public Vector3 sink;
    public RebuiltIce rebuilt;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rebuilt.goingUp);
        if(!rebuilt.goingUp)
        {
            timer += Time.deltaTime;

            if(timer >= limitTimer)
            {
                gameObject.transform.position += sink;
                //box2d.size += boxIncrease;
                timer = 0f;
                if(gameObject.transform.position.y <= -1)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
