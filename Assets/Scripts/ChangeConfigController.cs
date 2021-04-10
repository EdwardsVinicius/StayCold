using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeConfigController : MonoBehaviour
{
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    private int current=0;
    private GameObject currentGame;
    private bool canChange=false;
    private EventSystem even;

    // Start is called before the first frame update
    void Start()
    {
        even = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        changeSelectedMenu();
    }

    private void changeSelectedMenu()
    {
        if(currentGame != even.currentSelectedGameObject)
        {
            currentGame = activateOption(even.currentSelectedGameObject.name);
        }
    }

    private GameObject activateOption(string value)
    {
        if(value=="option1"){
            deactivateOption();
            option1.GetComponent<ActiveMenuOption>().ActivateOptionState();
            return option1;
        }
        if(value=="option2"){
            deactivateOption();
            option2.GetComponent<ActiveMenuOption>().ActivateOptionState();
            return option2;
        }
        if(value=="option3"){
            deactivateOption();
            option3.GetComponent<ActiveMenuOption>().ActivateOptionState();
            return option3;
        }
        return currentGame;
    }

    private void deactivateOption()
    {
        currentGame.GetComponent<ActiveMenuOption>().DeactivateOptionState();
    }
}
