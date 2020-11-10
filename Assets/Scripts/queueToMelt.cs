using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queueToMelt : MonoBehaviour
{
    public float timer = 0f;
    public float limitTimer = 20f;
    public bool haveOneMelting;
    [SerializeField]
    private List<GameObject> teste;
    //public Component teste2;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if(child.name == "Part1" || child.name == "Part2" || child.name == "Part4"
             || child.name == "Part5" || child.name == "Part6" || child.name == "Part7"
              || child.name == "Part8")
            {
                //print(child.name);
                teste.Add(child.gameObject);
            }
            //child.gameObject.SetActive(false);
        }
        haveOneMelting = false;
        //gameObjects.Add()
    }

    // Update is called once per frame
    void Update()
    {
        if(!haveOneMelting)
        {
            int teste2 = UnityEngine.Random.Range(0, 6);
            teste[teste2].GetComponent<meltingIce>().sink = new Vector3 (0, -0.05f, 0);
            haveOneMelting = true;
        }
        else{
            timer += Time.deltaTime;
            if(timer >= limitTimer)
            {
                haveOneMelting = false;
                timer=0f;
            }
        }
    }
}
