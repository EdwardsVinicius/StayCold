using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActiveWhenSelected : MonoBehaviour
{
    private EventSystem _event;
    public GameObject imagem;
    public GameObject texto;
    private int selectedSize = 120;
    private int unselectedSize = 70;
    private float valueToAddPosition = 20;
    private float y;
    private float x;
    private bool change=false;

    void Start()
    {
        _event = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        x = transform.position.x;
        y = transform.position.y;
    }

    void Update()
    {
        if(_event.currentSelectedGameObject == gameObject){
            ChangeImageState(true);
            ChangeFontSize(selectedSize);
            ChangeTextPosition(true);
            change=true;
        }else{
            if(imagem.activeSelf)
            {
                ChangeImageState(false);
                ChangeFontSize(unselectedSize);
                ChangeTextPosition(false);
                change=false;
            }
        }
    }

    void ChangeImageState(bool bol){
        imagem.SetActive(bol);
    }

    void ChangeFontSize(int value)
    {
        texto.GetComponent<Text>().fontSize = value;
    }

    void ChangeTextPosition(bool bol)
    {
        if(bol)
        {
            transform.position = new Vector2(x, y);
        }else{
            transform.position = new Vector2(x, y);
        }

    }
}
