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
    private Text medicPriceText;
    private Text influencerPriceText;
    private Text publicMPriceText;
    private Text researcherPriceText;
    private int medicPrice;
    private int influencerPrice;
    private int publicMPrice;
    private int researcherPrice;
    
    public localScript(string _name, int _ier, int _ihr, int _iir){
        name = _name;
        initial_economical_rate = _ier;
        initial_health_rate = _ihr;
        initial_industrial_rate = _iir;
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

    public int getMedicPrice(){
        return this.medicPrice;
    }

    public int getPublicMPrice(){
        return this.publicMPrice;
    }

    public int getResearcherPrice(){
        return this.researcherPrice;
    }

    public int getInfluencerPrice(){
        return this.influencerPrice;
    }

    public int getMedicCount(){
        return this.medicList.Count;
    }

    public int getResearcherCount(){
        return this.researchersList.Count;
    }

    public int getPManagerCount(){
        return this.publicManagerList.Count;
    }

    public int getInfluencerCount(){
        return this.influencersList.Count;
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

        medicPriceText = GameObject.Find("MPrice").GetComponent<Text>();
        publicMPriceText = GameObject.Find("PPrice").GetComponent<Text>();
        influencerPriceText = GameObject.Find("IPrice").GetComponent<Text>();
        researcherPriceText = GameObject.Find("RPrice").GetComponent<Text>();

        medicPrice = 100;
        publicMPrice = 100;
        influencerPrice = 100;
        researcherPrice = 100;
        updateCharacterPrice("Medic", medicPrice);
        updateCharacterPrice("PManager", publicMPrice);
        updateCharacterPrice("Influencer", influencerPrice);
        updateCharacterPrice("Researcher", researcherPrice);
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
        medicPrice += 100;
        updateCharacterPrice("Medic", medicPrice);
    }

    public void addNewPublicManager(){
        publicmanagerScript newPManager;
        newPManager = new publicmanagerScript("teste", 0, 0);
        this.publicManagerList.Add(newPManager);
        updateCharactersCount(medicList.Count, influencersList.Count, publicManagerList.Count, researchersList.Count);
        publicMPrice += 100;
        updateCharacterPrice("PManager", publicMPrice);
    }

    public void addNewInfluencer(){
        influencerScript newInfluencer;
        newInfluencer = new influencerScript("teste", 0, 0);
        this.influencersList.Add(newInfluencer);
        updateCharactersCount(medicList.Count, influencersList.Count, publicManagerList.Count, researchersList.Count);
        influencerPrice += 100;
        updateCharacterPrice("Influencer", influencerPrice);
    }

    public void addNewReasearcher(){
        researcherScript newResearcher;
        newResearcher = new researcherScript("teste", 0, 0);
        this.researchersList.Add(newResearcher);
        updateCharactersCount(medicList.Count, influencersList.Count, publicManagerList.Count, researchersList.Count);
        researcherPrice += 100;
        updateCharacterPrice("Researcher", researcherPrice);
    }

    public void updateCharactersCount(int mCounter, int ICounter, int PCounter, int RCounter){
        medicCounter.text = mCounter.ToString();
        influencerCounter.text = ICounter.ToString();
        publicMCounter.text = PCounter.ToString();
        researcherCounter.text = RCounter.ToString();
    }

    private void updateCharacterPrice(string character, int value){
        if(character.Equals("Medic")){
            medicPriceText.text = "R$ "+value+",00";
        }
        else if(character.Equals("PManager")){
            publicMPriceText.text = "R$ "+value+",00";
        }
        else if(character.Equals("Researcher")){
            researcherPriceText.text = "R$ "+value+",00";
        }
        else if(character.Equals("Influencer")){
            influencerPriceText.text = "R$ "+value+",00";
        }
    }
}