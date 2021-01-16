using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MessageDispatcher : MonoBehaviour
{
    public UnityEvent onAnimEvent;

    public void FireEvents()
    {
        Debug.Log("ActivatePlayerHitbox");
        onAnimEvent.Invoke();
    }
}
