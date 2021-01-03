using System.Collections.Generic;
using UnityEngine;

public class CalotasControllers : MonoBehaviour
{
    [Header("MELT VARIABLES")]

    public float timerMelt = 0f;
    public float limitTimerMelt = 20f;
    public bool haveOneMelting;
    [SerializeField]
    private List<GameObject> queueToMelt;

    [Header("REBUILT VARIABLES")]

    [SerializeField]
    private List<GameObject> queueToRebuilt;

    private void Awake()
    {
        haveOneMelting = false;
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
        RandomMeltTime();
    }

    void RandomMeltTime()
    {
        timerMelt += Time.deltaTime;

        if (timerMelt >= limitTimerMelt)
        {
            timerMelt = 0f;

            // Se uma calota estiver derretendo, então não haverá outro derretimento aleatório
            if (!haveOneMelting) MeltingRandomCalota();
        }
    }

    void MeltingRandomCalota()
    {
        if (queueToMelt.Count != 0)
        {
            int sortedCalota = Random.Range(0, queueToMelt.Count - 1);

            MeltingCalota(queueToMelt[sortedCalota]);  
        }
        else // Game Over
        { 
            Debug.Log("Sem calotas para derreter");
        }
    }

    void MeltingCalota(GameObject calota)
    {
        if (calota.GetComponent<Calota>().beingBuilt == false)
        {
            haveOneMelting = true;
            calota.transform.GetComponent<Calota>().beingMelted = true;

            if (calota.GetComponent<Calota>().beingMelted == true)
            {
                LeanTween.moveLocalY(calota.gameObject, -0.02f, 1f);
                LeanTween.moveLocalY(calota.gameObject, -1f, 5f).setDelay(10f);
                
                for (int i = 0; i < calota.gameObject.transform.childCount; i++)
                {
                    calota.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                    // ativa o trigger para q o urso possa detectar colisao com a calota derretida
                    calota.gameObject.transform.GetChild(i).GetComponent<MeshCollider>().isTrigger = true;
                }

                if (queueToRebuilt.Contains(calota) == false) queueToRebuilt.Add(calota);

                if (queueToRebuilt.Contains(calota) == true) queueToMelt.Remove(calota);
            }
        }
    }
    
    public void RebuildingCalota(GameObject calota)
    {
        if (calota.transform.GetChild(0).GetComponent<MeshRenderer>().enabled == false)
        {
            // se a calota estiver derretendo, o urso ainda pode reconstrui-la antes q o derretimento seja completo
            if(calota.transform.GetComponent<Calota>().beingMelted == true)
            {
                LeanTween.cancel(calota);
                calota.transform.GetComponent<Calota>().beingMelted = false;
                haveOneMelting = false;
                timerMelt = 0;
                // calota.transform.GetComponent<Calota>().beingBuilt = true;
            }

            calota.transform.GetComponent<Calota>().beingBuilt = true;

            Debug.Log("SUBINDO " + calota);
            LeanTween.moveLocalY(calota.gameObject, 0f, 3f);

            for (int j = 0; j < calota.gameObject.transform.childCount; j++)
            {
                calota.transform.GetChild(j).GetComponent<MeshRenderer>().enabled = true;
                // desativa o trigger para q o urso não possa mais detectar colisao com a calota agora reconstruida
                calota.gameObject.transform.GetChild(j).GetComponent<MeshCollider>().isTrigger = false;
            }

            if (queueToMelt.Contains(calota) == false) queueToMelt.Add(calota);

            if (queueToRebuilt.Contains(calota) == true) queueToRebuilt.Remove(calota);
        }       
    }
}
