using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New event", menuName = "Event")]
public class eventScript : ScriptableObject
{
    public int during_time;
    public int event_ID;
    public string event_name;
    public string event_description;

    public int getDuringTime(){
    return this.during_time;
    }

    public int getID(){
        return this.event_ID;
    }

    public string getEventName(){
        return this.event_name;
    }

    public string getEventDescription(){
        return this.event_description;
    }
}