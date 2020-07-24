using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Text medicCounter;
    private Text influencerCounter;
    private Text publicMCounter;
    private Text researcherCounter;
    private Text medicValueText;
    private Text influencerValueText;
    private Text publicMValueText;
    private Text researcherValueText;
    private int medicValue;
    private int influencerValue;
    private int publicMValue;
    private int researcherValue;
    
    public localScript(string _name, int _ier, int _ihr, int _iir){
        name = _name;
        initial_economical_rate = _ier;
        initial_health_rate = _ihr;
        initial_industrial_rate = _iir;
    }

    private void Start() {
        //initializeAll();
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

    public int getMedicValue(){
        return this.medicValue;
    }

    public int getPublicMValue(){
        return this.publicMValue;
    }

    public int getResearcherValue(){
        return this.researcherValue;
    }

    public int getInfluencerValue(){
        return this.influencerValue;
    }

    //FUNCTIONS
    public void initializeAll(){
        economical_rate = initial_economical_rate;
        health_rate = initial_health_rate;
        industrial_rate = initial_industrial_rate;
        medicList = new List<medicScript>();
        publicManagerList = new List<publicmanagerScript>();
        influencersList = new List<influencerScript>();
        researchersList = new List<researcherScript>();   

        medicCounter = GameObject.Find("MCounter").GetComponent<Text>(); 
        influencerCounter = GameObject.Find("ICounter").GetComponent<Text>(); 
        publicMCounter = GameObject.Find("PCounter").GetComponent<Text>(); 
        researcherCounter = GameObject.Find("RCounter").GetComponent<Text>(); 
        updateCharactersCount(medicList.Count, influencersList.Count, publicManagerList.Count, researchersList.Count);

        medicValueText = GameObject.Find("MValue").GetComponent<Text>();
        publicMValueText = GameObject.Find("PValue").GetComponent<Text>();
        influencerValueText = GameObject.Find("IValue").GetComponent<Text>();
        researcherValueText = GameObject.Find("RValue").GetComponent<Text>();

        medicValue = 100;
        publicMValue = 100;
        influencerValue = 100;
        researcherValue = 100;
        updateCharacterValue("Medic", medicValue);
        updateCharacterValue("PManager", publicMValue);
        updateCharacterValue("Influencer", influencerValue);
        updateCharacterValue("Researcher", researcherValue);
    }

    public void updateEconomicalRate(int value){
        this.economical_rate += value;
    }

    public void updateHealthRate(int value){
        this.health_rate += value;
    }

    public void updateIndustrialalRate(int value){
        this.industrial_rate += value;
    }

    public void addNewMedic(){
        medicScript newMedic;
        newMedic = new medicScript("teste", 0, 0);
        this.medicList.Add(newMedic);
        updateCharactersCount(medicList.Count, influencersList.Count, publicManagerList.Count, researchersList.Count);
        medicValue += 100;
        updateCharacterValue("Medic", medicValue);
    }

    public void addNewPublicManager(){
        publicmanagerScript newPManager;
        newPManager = new publicmanagerScript("teste", 0, 0);
        this.publicManagerList.Add(newPManager);
        updateCharactersCount(medicList.Count, influencersList.Count, publicManagerList.Count, researchersList.Count);
        publicMValue += 100;
        updateCharacterValue("PManager", publicMValue);
    }

    public void addNewInfluencer(){
        influencerScript newInfluencer;
        newInfluencer = new influencerScript("teste", 0, 0);
        this.influencersList.Add(newInfluencer);
        updateCharactersCount(medicList.Count, influencersList.Count, publicManagerList.Count, researchersList.Count);
        influencerValue += 100;
        updateCharacterValue("Influencer", influencerValue);
    }

    public void addNewReasearcher(){
        researcherScript newResearcher;
        newResearcher = new researcherScript("teste", 0, 0);
        this.researchersList.Add(newResearcher);
        updateCharactersCount(medicList.Count, influencersList.Count, publicManagerList.Count, researchersList.Count);
        researcherValue += 100;
        updateCharacterValue("Researcher", researcherValue);
    }

    public void updateCharactersCount(int mCounter, int ICounter, int PCounter, int RCounter){
        medicCounter.text = mCounter.ToString();
        influencerCounter.text = ICounter.ToString();
        publicMCounter.text = PCounter.ToString();
        researcherCounter.text = RCounter.ToString();
    }

    private void updateCharacterValue(string character, int value){
        if(character.Equals("Medic")){
            medicValueText.text = "R$ "+value+",00";
        }
        else if(character.Equals("PManager")){
            publicMValueText.text = "R$ "+value+",00";
        }
        else if(character.Equals("Researcher")){
            researcherValueText.text = "R$ "+value+",00";
        }
        else if(character.Equals("Influencer")){
            influencerValueText.text = "R$ "+value+",00";
        }
    }
}