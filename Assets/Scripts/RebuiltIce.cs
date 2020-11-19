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

    public Button rebuiltBtn;

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

        print(queueToRebuilt.Count);
    }

    void Update()
    {
        if(goingUp)
        {
            int x = 0;
            while (goingUp == true)
            {
                if(queueToRebuilt[x].activeInHierarchy == false)
                {
                    queueToRebuilt[x].gameObject.SetActive(true);
                    timer += Time.deltaTime;
                    if(timer >= limitTimer){
                        goingUp = false;
                    }else{
                        queueToRebuilt[x].gameObject.transform.position += upp;
                        if (queueToRebuilt[x].gameObject.transform.position.y >= 0)
                        {
                            goingUp = false;
                        }
                    }
                }
                else if (x >= 6)
                {
                    goingUp = false;
                }
                x++;
            }
        }
        // else{
        //     timer += Time.deltaTime;
        //     if(timer >= limitTimer){
        //         timer = 0f;
        //     }
        // }
    }

    public void rebuiltPlatform()
    {
        goingUp = true;
    }

}
