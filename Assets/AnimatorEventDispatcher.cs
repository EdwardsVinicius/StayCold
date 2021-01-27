using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorEventDispatcher : MonoBehaviour
{
    [Serializable]
    public struct AnimationEvent
    {
        public string eventName;
        public UnityEvent triggeredEvents;
    }

    public AnimationEvent[] eventListeners;

    public void FireListener(string eventName)
    {
        for (int i = 0; i < eventListeners.Length; i++)
        {
            if(eventListeners[i].eventName == eventName)
            {
                eventListeners[i].triggeredEvents.Invoke();
            }
        }
    }
}
