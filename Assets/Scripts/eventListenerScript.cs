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
    
    /*public void initializeEvents(List<eventScript> events){
        int i;
        for(i=events.Count-1; i >= 0; i--){
            Response.AddListener(() => this.gameObject.GetComponent<controllerScript>().activateEvent(events[i].event_ID));
            print("inicianlizando evento "+events[i].event_name);
        }
    }*/

    public void onEventRaised(eventScript incomingEvent){
        Response.Invoke();
    }
}