using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTriggerScript : MonoBehaviour
{
    private controllerScript controller;
    private localScript local;
    public List<eventScript> eventsList;
    private int prevDay;

    private void Start() {
        controller = GameObject.Find("MainController").GetComponent<controllerScript>();
        local = GameObject.Find("GamePanel").GetComponent<localScript>();
        foreach(eventScript nEvent in eventsList){
            nEvent.activatedEvent = false;
        }
    }

    private void Update() {
        if(controller.getStartFlag() && eventsList[0].activatedEvent == false)   executeEvent(0);
        if(controller.getDaysCounter() > prevDay){
            checkEvents();
            prevDay = controller.getDaysCounter();
        }
    }

    private void checkEvents(){
        if(probability(controller.getDaysCounter()*2) && eventsList[1].activatedEvent == false)    executeEvent(1); //10% por dia
        if(probability(local.getResearcherCount()*5) && eventsList[2].activatedEvent == false)    executeEvent(2);  //25% por pesquisador
        if(controller.getDaysCounter()>10 && probability(8-(local.getMedicCount()*2)) && eventsList[3].activatedEvent == false)    executeEvent(3);
        if(controller.getDaysCounter()>15 && probability(12-(local.getInfluencerCount()*2)) && eventsList[4].activatedEvent == false)    executeEvent(4);
        if(controller.getDaysCounter()>20 && probability((local.getMedicCount()*3)) && eventsList[5].activatedEvent == false)    executeEvent(5);
        if(controller.getDaysCounter()>25 && probability((local.getInfluencerCount()*3)) && eventsList[6].activatedEvent == false)    executeEvent(6);
    }

    private void executeEvent(int id){
        eventsList[id].Raise();
    }

    private bool probability(int chance){
        int result;

        result = Random.Range(0, 100);

        if(result <= 5*chance)
            return true;
        
        return false;
    }
}
