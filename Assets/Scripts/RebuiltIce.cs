using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebuiltIce : MonoBehaviour
{

    //public GameObject gameObject;
    //public Button rebuiltBtn;

    public float timer = 0f;
    public float limitTimer = 5f;
    public Vector3 upp;
    public bool goingUp;

    [SerializeField]
    private List<GameObject> queueToRebuilt;

    private void Awake()
    {
        goingUp = false;
    }
    void Start()
    {
        //rebuiltBtn.onClick.AddListener(rebuiltPlatform);
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if(child.name == "Part1" || child.name == "Part2" || child.name == "Part4"
             || child.name == "Part5" || child.name == "Part6" || child.name == "Part7"
              || child.name == "Part8")
            {
                queueToRebuilt.Add(child.gameObject);
            }
        }
        goingUp = false;
    }

    void Update()
    {
        if(goingUp)
        {
            timer += Time.deltaTime;
            if(timer >= limitTimer)
            {
                timer = 0f;
                /*gameObject.transform.position += upp;
                if(gameObject.transform.position.y >= 0)
                {
                    goingUp = false;
                }*/
            }
        }
    }

    public void rebuiltPlatform()
    {
        //gameObject.transform.position = new Vector3Int(1,1,1);
        //gameObject.SetActive(true);
        int x = 0;
        goingUp = true;
        while (goingUp == true)
        {
            print(queueToRebuilt[x]);
            if(queueToRebuilt[x].activeInHierarchy == false)
            {
                queueToRebuilt[x].gameObject.transform.position += upp;
                if (queueToRebuilt[x].gameObject.transform.position.y >= 0)
                {
                    goingUp = false;
                }
            }

            x++;
        }
    }

}
