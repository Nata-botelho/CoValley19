using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventListenerScript : MonoBehaviour
{
    public eventScript gameEvent;

    public UnityEvent Response;

    private void OnEnable() {
        gameEvent.registerListener(this);
    }

    private void OnDisable() {
        gameEvent.unrigisterListener(this);
    }

    public void onEventRaised(eventScript incomingEvent){
        Response.Invoke();
        this.enabled = false;
    }
}