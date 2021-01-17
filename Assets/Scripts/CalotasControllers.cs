using System.Collections.Generic;
using UnityEngine;

public class CalotasControllers : MonoBehaviour
{
    [Header("TOTAL DE CALOTAS")]

    public List<GameObject> calotas;
    
    [Header("MELT VARIABLES")]

    public float timerMelt = 0f;
    public float limitTimerMelt = 20f;
    public bool haveOneMelting;
    GameObject sortedCalota;
    private static readonly float alertMeltingPosition = Calota.meltedPosition - 0.6f;
    // [SerializeField]

    [Header("REBUILT VARIABLES")]

    [SerializeField]
    private List<GameObject> queueToRebuilt;

    private void Awake()
    {
        haveOneMelting = false;
    }

    void Start()
    {
        // se i começar com 1 a calota Limite Fim não é adicionada
        for (int i = 1; i < this.GetComponentInChildren<Transform>().childCount; i++)
        {
            //Debug.Log(this.GetComponentInChildren<Transform>().GetChild(i).name);
            calotas.Add(this.GetComponentInChildren<Transform>().GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(calotas.Count > 0)
        {
            RandomMeltTime();

            if (sortedCalota!=null && sortedCalota.GetComponent<Calota>().beingMelted == true)
            {
                // Debug.Log(queueToMelt[sortedCalota].name + ": " + queueToMelt[sortedCalota].transform.localPosition.y);
                if (sortedCalota.transform.localPosition.y == Calota.meltedPosition)
                {
                    OnOffCalota(sortedCalota, false, true);
                    sortedCalota.transform.GetComponent<Calota>().beingMelted = false;

                    if (queueToRebuilt.Contains(sortedCalota) == false) queueToRebuilt.Add(sortedCalota);

                    if (queueToRebuilt.Contains(sortedCalota) == true) calotas.Remove(sortedCalota);
                    haveOneMelting = false;
                }
            }
        }
        // else GAME OVER
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

    public GameObject ChooseRandomCalota()
    {
        var sortedCalota = Random.Range(0, calotas.Count);

        if (calotas[sortedCalota].GetComponent<Calota>().willBeDestroyed == true || calotas[sortedCalota].GetComponent<Calota>().beingMelted == true)
        {
            Debug.Log("Sorteando outra calota");
            return ChooseRandomCalota();
        }
        else
        {
            // Debug.Log("sortedCalota: " + sortedCalota);
            return calotas[sortedCalota];
        }

    }

    void MeltingRandomCalota()
    {
        sortedCalota = ChooseRandomCalota();

        Debug.Log("MeltingCalota: " + sortedCalota);
        MeltingCalota(sortedCalota);
    }

    public void OnOffCalota(GameObject calota, bool enabled, bool isTrigged)
    {
        // Debug.Log("CALOTA: " + calota.name);
        for (int i = 0; i < calota.transform.childCount; i++)
        {
            GameObject iceTile = calota.transform.GetChild(i).gameObject;
            // Debug.Log("ICE TILE: " + iceTile.name);
            for (int j = 0; j < iceTile.transform.childCount; j++)
            {
                iceTile.transform.GetChild(j).GetComponent<MeshRenderer>().enabled = enabled;
                // desativa o trigger para q o urso não possa mais detectar colisao com a calota agora reconstruida
                iceTile.transform.GetChild(j).GetComponent<MeshCollider>().isTrigger = isTrigged;
            }
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
                LeanTween.moveLocalY(calota.gameObject, alertMeltingPosition, 1f);

                // OnOffCalota(calota, false, true);

                LeanTween.moveLocalY(calota.gameObject, Calota.meltedPosition, 5f).setDelay(10f);
            }
        }
    }

    // função para ser usada pelo Magma_Creep
    public void DestroyCalota(GameObject calota)
    {
        if ((calotas.Contains(calota) == true))
        {
            OnOffCalota(calota, false, true);
            LeanTween.moveLocalY(calota.gameObject, Calota.meltedPosition, 5f);
            calota.GetComponent<Calota>().willBeDestroyed = false;
            queueToRebuilt.Add(calota);
            calotas.Remove(calota);
        }
    }

    public void RebuildingCalota(GameObject calota)
    {
        // se a calota estiver derretendo, o urso ainda pode reconstrui-la antes q o derretimento seja completo
        if (calota.transform.GetComponent<Calota>().beingMelted == true)
        {
            LeanTween.cancel(calota);
            calota.transform.GetComponent<Calota>().beingMelted = false;
            haveOneMelting = false;
            timerMelt = 0;
            calota.transform.GetComponent<Calota>().beingBuilt = true;

            // Debug.Log("SUBINDO " + calota);
            LeanTween.moveLocalY(calota.gameObject, Calota.builtPosition, 3f);
        }

        if (calota.transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>().enabled == false)
        {
            calota.transform.GetComponent<Calota>().beingBuilt = true;

            // Debug.Log("SUBINDO " + calota);
            LeanTween.moveLocalY(calota.gameObject, Calota.builtPosition, 3f);

            OnOffCalota(calota, true, false);

            if (calotas.Contains(calota) == false) calotas.Add(calota);

            if (queueToRebuilt.Contains(calota) == true) queueToRebuilt.Remove(calota);
        }
    }
}
