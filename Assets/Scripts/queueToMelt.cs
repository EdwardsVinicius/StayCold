using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueToMelt : MonoBehaviour
{
    public float timer = 0f;
    public float limitTimer = 20f;
    public bool haveOneMelting;
    [SerializeField]
    private List<GameObject> toMelt;

    void Start()
    {
        // i começa com 1 só para não adicionar a calota Limite Fim
        for(int i = 1; i < this.GetComponentInChildren<Transform>().childCount; i++)
        {
            //Debug.Log(this.GetComponentInChildren<Transform>().GetChild(i).name);
            toMelt.Add(this.GetComponentInChildren<Transform>().GetChild(i).gameObject);
        }

        haveOneMelting = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if(!haveOneMelting)
        {
            int teste2 = Random.Range(0, 6);
            toMelt[teste2].GetComponent<MeltingIce>().sink = new Vector3 (0, -0.2f, 0);
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
