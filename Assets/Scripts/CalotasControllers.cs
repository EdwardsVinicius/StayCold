using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalotasControllers : MonoBehaviour
{
    [Header("MELT VARIABLES")]

    public float timerMelt = 0f;
    public float limitTimerMelt = 20f;
    public static bool haveOneMelting;
    // public Vector3 sink;
    [SerializeField]
    private List<GameObject> queueToMelt;

    [Header("REBUILT VARIABLES")]

    public float timerRebuilt = 0f;
    public float limitTimerRebuilt = 5f;
    public Vector3 upp;
    // public static bool goingUp;
    [SerializeField]
    private List<GameObject> queueToRebuilt;

    private void Awake()
    {
        haveOneMelting = false;
        // goingUp = false;
    }

    void Start()
    {
        // i começa com 1 só para não adicionar a calota Limite Fim
        for (int i = 1; i < this.GetComponentInChildren<Transform>().childCount; i++)
        {
            //Debug.Log(this.GetComponentInChildren<Transform>().GetChild(i).name);
            queueToMelt.Add(this.GetComponentInChildren<Transform>().GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MeltingRandomCalota();
    }

    void MeltingRandomCalota()
    {
        if (queueToMelt.Count != 0)
        {
            // Debug.Log(haveOneMelting);
            if (!haveOneMelting) // sE NÃO TIVER NENHUM DERRETENDO, SORTEIA UM PRA DERRETER
            {
                //Debug.Log(haveOneMelting);
                int sortCalota = Random.Range(0, queueToMelt.Count - 1);
                
                //sink = new Vector3(0, -0.2f, 0);

                MeltingCalota(queueToMelt[sortCalota]);

                if (queueToRebuilt.Contains(queueToMelt[sortCalota]) == false) queueToRebuilt.Add(queueToMelt[sortCalota]);
                
                if (queueToRebuilt.Contains(queueToMelt[sortCalota]) == true) queueToMelt.RemoveAt(sortCalota);

                // Debug.Log(queueToMelt.Count - 1);
                haveOneMelting = true;
            }
            else
            {
                timerMelt += Time.deltaTime;

                if (timerMelt >= limitTimerMelt)
                {
                    haveOneMelting = false;
                    timerMelt = 0f;
                }
            }
        }
        else
        {
            Debug.Log("Sem calotas para derreter");
        }
    }

    void MeltingCalota(GameObject calota)
    {
        /*
        for (int i = 0; i < calota.gameObject.transform.childCount; i++)
        {
            calota.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
        */


        if (calota.GetComponent<Calota>().beingBuilt == false)
        {
            LeanTween.moveLocalY(calota.gameObject, -1f, 10f).setEase(LeanTweenType.easeInQuad).setDelay(1f);

            for (int i = 0; i < calota.gameObject.transform.childCount; i++)
            {
                calota.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                // ativa o trigger para q o urso possa detectar colisao com a calota derretida
                calota.gameObject.transform.GetChild(i).GetComponent<MeshCollider>().isTrigger = true;
            }
            /*
            if (calota.gameObject.transform.position.y <= -1)
            {
                for (int i = 0; i < calota.gameObject.transform.childCount; i++)
                {
                    calota.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                }
            }
            */
        }
    }
    
    public void RebuildingCalota(GameObject calota)
    {
        if (calota.transform.GetChild(0).GetComponent<MeshRenderer>().enabled == false)
        {
            calota.transform.GetComponent<Calota>().beingBuilt = true;
            // goingUp = true;

            Debug.Log("SUBINDO " + calota);
            LeanTween.moveLocalY(calota.gameObject, 0f, 2f).setEase(LeanTweenType.easeInQuad).setDelay(1f);

            for (int j = 0; j < calota.gameObject.transform.childCount; j++)
            {
                calota.transform.GetChild(j).GetComponent<MeshRenderer>().enabled = true;
                // desativa o trigger para q o urso não possa mais detectar colisao com a calota agora reconstruida
                calota.gameObject.transform.GetChild(j).GetComponent<MeshCollider>().isTrigger = false;
            }

            // goingUp = false;

            if (queueToMelt.Contains(calota) == false) queueToMelt.Add(calota);

            if (queueToRebuilt.Contains(calota) == true) queueToRebuilt.Remove(calota);

            // calota.GetComponent<MeltingIce>().sink = new Vector3(0, Time.deltaTime, 0);
            // calota.GetComponent<MeltingIce>().stillGoing = true;
            


            timerRebuilt += Time.deltaTime;
    
            if (timerRebuilt >= limitTimerRebuilt)
            {
                // goingUp = false;
                calota.transform.GetComponent<Calota>().beingBuilt = false;
            }
            else
            {
                calota.gameObject.transform.position += upp;

                if (calota.transform.position.y >= 0f)
                {
                    // goingUp = false;
                    calota.transform.GetComponent<Calota>().beingBuilt = false;
                }
            }
            
        }
        else
        {
            calota.transform.GetComponent<Calota>().beingBuilt = false;

            timerRebuilt += Time.deltaTime;

            if (timerRebuilt >= limitTimerRebuilt)
            {
                timerRebuilt = 0f;
            }
        }
    }
}
