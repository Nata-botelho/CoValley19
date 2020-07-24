using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTriggerScript : MonoBehaviour
{
    
    public List<eventScript> eventsList;

    private void Start() {
        //this.gameObject.GetComponent<eventListenerScript>().initializeEvents(eventsList);
    }

    public void executeEvent(int id){
        eventsList[id].Raise();
    }
}
