﻿using System.Collections.Generic;
using UnityEngine;

public class CalotasControllers : MonoBehaviour
{
    [Header("MELT VARIABLES")]

    public float timerMelt = 0f;
    public float limitTimerMelt = 20f;
    public bool haveOneMelting;
    int sortedCalota;
    private static readonly float alertMeltingPosition = Calota.meltedPosition - 0.6f;
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

        if (queueToMelt.Count != 0 && queueToMelt[sortedCalota].transform.GetComponent<Calota>().beingMelted == true)
        {
            // Debug.Log(queueToMelt[sortedCalota].name + ": " + queueToMelt[sortedCalota].transform.position.y);
            if (queueToMelt[sortedCalota].transform.position.y == Calota.meltedPosition - 2f)
            {
                OnOffCalota(queueToMelt[sortedCalota], false, true);
                queueToMelt[sortedCalota].transform.GetComponent<Calota>().beingMelted = false;

                if (queueToRebuilt.Contains(queueToMelt[sortedCalota]) == false) queueToRebuilt.Add(queueToMelt[sortedCalota]);

                if (queueToRebuilt.Contains(queueToMelt[sortedCalota]) == true) queueToMelt.Remove(queueToMelt[sortedCalota]);
                haveOneMelting = false;
            }
        }
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
            sortedCalota = Random.Range(0, queueToMelt.Count - 1);
            // Debug.Log("sortedCalota: " + sortedCalota);
            // Debug.Log("MeltingCalota: " + queueToMelt[sortedCalota]);

            MeltingCalota(queueToMelt[sortedCalota]);  
        }
        else // Game Over
        { 
            Debug.Log("Sem calotas para derreter");
        }
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

            if (queueToMelt.Contains(calota) == false) queueToMelt.Add(calota);

            if (queueToRebuilt.Contains(calota) == true) queueToRebuilt.Remove(calota);
        }       
    }
}