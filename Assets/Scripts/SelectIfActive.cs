using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectIfActive : MonoBehaviour
{
    private bool activated = false;
    public GameObject buttonToActivate;
    private EventSystem _event;
    // Start is called before the first frame update
    void Start()
    {
        _event = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    void Update()
    {
        if(gameObject.activeSelf && !activated)
        {
            activated = !activated;
            _event.SetSelectedGameObject(buttonToActivate);
        }
    }
}
