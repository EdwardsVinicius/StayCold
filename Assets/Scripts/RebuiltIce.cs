using System.Collections.Generic;
using UnityEngine;

public class RebuiltIce : MonoBehaviour
{
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
        // i começa com 1 só para não adicionar a calota Limite Fim
        for (int i = 1; i < this.GetComponentInChildren<Transform>().childCount; i++)
        {
            //Debug.Log(this.GetComponentInChildren<Transform>().GetChild(i).name);
            queueToRebuilt.Add(this.GetComponentInChildren<Transform>().GetChild(i).gameObject);
        }
    }

    void Update()
    {
        
        if(goingUp)
        {
            int x = 0;
            while (goingUp == true)
            {
                if(queueToRebuilt[x].transform.GetChild(0).GetComponent<MeshRenderer>().enabled == false)
                {
                    Debug.Log("SUBINDO " + queueToRebuilt[x]);

                    for (int j = 0; j < queueToRebuilt[x].gameObject.transform.childCount; j++)
                    {
                        LeanTween.moveLocalY(queueToRebuilt[x].gameObject, 0f, 1f).setEase(LeanTweenType.easeInQuad).setDelay(1f);
                        queueToRebuilt[x].transform.GetChild(j).GetComponent<MeshRenderer>().enabled = true;
                    }

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
    
    /*
    public void RebuiltPlatform()
    {
        goingUp = true;
    }
    */
    

    
    public void RebuiltPlatform(GameObject calotas)
    {
        goingUp = true;

        while (goingUp == true)
        {
            for (int i = 0; i < calotas.gameObject.transform.childCount; i++)
            {
                LeanTween.moveLocalY(this.gameObject, 0f, 1f).setEase(LeanTweenType.easeInQuad).setDelay(1f);
                calotas.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
            }

            timer += Time.deltaTime;

            if (timer >= limitTimer)
            {
                goingUp = false;
            }
            else
            {
                calotas.gameObject.transform.position += upp;
                if (calotas.gameObject.transform.position.y >= 0)
                {
                    goingUp = false;
                }
            }
            
        }
    }
    
}
