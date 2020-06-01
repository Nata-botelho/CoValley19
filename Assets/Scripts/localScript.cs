using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localScript : MonoBehaviour
{
    private readonly string localName;
    private readonly int initial_economical_rate;
    private readonly int initial_health_rate;
    private readonly int initial_industrial_rate;
    private int economical_rate;
    private int health_rate;
    private int industrial_rate;
    private List<medicScript> medicList;
    private List<publicmanagerScript> publicManagerList;
    private List<influencerScript> influencersList;
    private List<researcherScript> researchersList;

    public localScript(string _name, int _ier, int _ihr, int _iir){
        name = _name;
        initial_economical_rate = _ier;
        initial_health_rate = _ihr;
        initial_industrial_rate = _iir;
    }

    private void Start() {
        economical_rate = initial_economical_rate;
        health_rate = initial_health_rate;
        industrial_rate = initial_industrial_rate;
        medicList = new List<medicScript>();
        publicManagerList = new List<publicmanagerScript>();
        influencersList = new List<influencerScript>();
        researchersList = new List<researcherScript>();    
    }

    private void Update() {
        
    }

    //GETTERS
    public int getEconomicalRate(){
        return this.economical_rate;
    }

    public int getHealthRate(){
        return this.health_rate;
    }

    public int getIndustrialRate(){
        return this.industrial_rate;
    }

    public medicScript[] getMedicsList(){
        medicScript[] copy = new medicScript[20];
        this.medicList.CopyTo(copy);
        return copy;
    }

    public publicmanagerScript[] getPublicManagersList(){
        publicmanagerScript[] copy = new publicmanagerScript[20];
        this.publicManagerList.CopyTo(copy);
        return copy;
    }

    public influencerScript[] getInfluencersList(){
        influencerScript[] copy = new influencerScript[20];
        this.influencersList.CopyTo(copy);
        return copy;
    }

    public researcherScript[] getResearchersList(){
        researcherScript[] copy = new researcherScript[20];
        this.researchersList.CopyTo(copy);
        return copy;
    }

    //FUNCTIONS
    public void updateEconomicalRate(int value){
        this.economical_rate += value;
    }

    public void updateHealthRate(int value){
        this.health_rate += value;
    }

    public void updateIndustrialalRate(int value){
        this.industrial_rate += value;
    }

    public void addNewMedic(medicScript newMedic){
        this.medicList.Add(newMedic);
    }

    public void addNewPublicManager(publicmanagerScript newPManager){
        this.publicManagerList.Add(newPManager);
    }

    public void addNewInfluencer(influencerScript newInfluencer){
        this.influencersList.Add(newInfluencer);
    }

    public void addNewReasearcher(researcherScript newResearcher){
        this.researchersList.Add(newResearcher);
    }
}
