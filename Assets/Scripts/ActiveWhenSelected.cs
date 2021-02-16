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
    public float valueToAddPosition = 20;
    private float Y;
    private float X;

    void Start()
    {
        _event = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        x = transform.postion.x;
        y = transform.postion.y;
    }

    void Update()
    {
        if(_event.currentSelectedGameObject == gameObject){
            ChangeImageState(true);
            ChangeFontSize(selectedSize);
        }else{
            if(imagem.activeSelf)
            {
                ChangeImageState(false);
                ChangeFontSize(unselectedSize);
                ChangeTextPosition(false);
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
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y+20);
        }else{
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        }

    }
}
