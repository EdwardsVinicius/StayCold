using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveWhenSelected : MonoBehaviour
{
    private EventSystem _event;
    public GameObject imagem;

    void Start()
    {
        _event = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    void Update()
    {
        if(_event.currentSelectedGameObject == gameObject){
            imagem.SetActive(true);
        }else{
            if(imagem.activeSelf)
            {
                imagem.SetActive(false);
            }
        }
    }
}
