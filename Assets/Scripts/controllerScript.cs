using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerScript : MonoBehaviour
{
    private Canvas mainMenu;
    private Canvas gameScreen;
    private Canvas endGameScreen;
    private GameObject defeatScreen;
    private GameObject victoryScreen;
    private Slider contamination_slider;
    private Text contamination_percent;
    private Slider research_slider;
    private Text research_percent;
    private Text daysUI;
    private Text moneyUI;

    private float timer;
    private float day_duration;

    private int days_counter;
    private int research_progress;
    private int contamination_rate;
    private int money_counter;

    private int incResearchValue;
    private int incContamiValue;
    private int incMoneyValue;
    private int lastResearcherCounter = 0;

    private List<skillTreeScript> skill_tree;
    private localScript local;
    private playerScript player;

    private Button medicButton;
    private Button influencerButton;
    private Button publicMButton;
    private Button researcherButton;

    private bool startedFlag = false;
    private Button startButton;
    private Button restartButton;
    private Button creditsButton;
    private Button endGameButton;

    private Text eventName;
    private Text eventDescription;

    public controllerScript(localScript _local, playerScript _player){
        this.local = _local;
        this.player = _player;
    }

    private void Start() {
        initializeAll();
    }

    private void Update() {
        if(startedFlag){
            elapseTime(incResearchValue, incContamiValue, incMoneyValue);

        }
        checkEndGame();
    }

    //GETTERS
    public int getDaysCounter(){
        return this.days_counter;
    }

    public int getResearchProgress(){
        return this.research_progress;
    }

    public int getContaminationRate(){
        return this.contamination_rate;
    }

    public bool getStartFlag(){
        return this.startedFlag;
    }

    //FUNCTIONS
    private void initializeAll(){
        mainMenu = GameObject.Find("MainMenu").GetComponent<Canvas>();
        gameScreen = GameObject.Find("GameScreen").GetComponent<Canvas>();
        endGameScreen = GameObject.Find("EndGame").GetComponent<Canvas>();
        local = GameObject.Find("GamePanel").GetComponent<localScript>();
        contamination_slider = GameObject.Find("Contam.Slider").GetComponent<Slider>();
        contamination_percent = GameObject.Find("Contam.Percent").GetComponent<Text>();
        research_slider = GameObject.Find("Research.Slider").GetComponent<Slider>();
        research_percent = GameObject.Find("Research.Percent").GetComponent<Text>();
        daysUI = GameObject.Find("DaysCounter").GetComponent<Text>();
        moneyUI = GameObject.Find("MoneyCounter").GetComponent<Text>();
        medicButton = GameObject.Find("MButton").GetComponent<Button>();
        publicMButton = GameObject.Find("PButton").GetComponent<Button>();
        researcherButton = GameObject.Find("RButton").GetComponent<Button>();
        influencerButton = GameObject.Find("IButton").GetComponent<Button>();
        medicButton.onClick.AddListener(buyMedics);
        publicMButton.onClick.AddListener(buyPManagers);
        researcherButton.onClick.AddListener(buyResearchers);
        influencerButton.onClick.AddListener(buyInfluencers);
        startButton = GameObject.Find("newGameButton").GetComponent<Button>();
        creditsButton = GameObject.Find("creditsButton").GetComponent<Button>();
        endGameButton = GameObject.Find("exitButton").GetComponent<Button>();
        restartButton = GameObject.Find("restartGameButton").GetComponent<Button>();
        restartButton.onClick.AddListener(startGame);
        startButton.onClick.AddListener(startGame);
        defeatScreen = GameObject.Find("DefeatScreen");
        victoryScreen = GameObject.Find("VictoryScreen");
        eventName = GameObject.Find("eventName").GetComponent<Text>();
        eventDescription = GameObject.Find("eventDescription").GetComponent<Text>();
    }

    private void incrementDays(){
        days_counter += 1;
    }

    private void updateDays(int value){
        daysUI.text = value.ToString();
    }

    public void incrementResearchValue(int value){
        incResearchValue += value;
    }

    private void incrementResearchProgress(int value){
        research_progress += value;
    }

    private void updateResearchSlider(int value){
        research_slider.value = value;
        research_percent.text = value+"%";
    }

    public void incrementContaminationValue(int value){
        incContamiValue += value;
        print("cont value agr eh: "+incContamiValue);
    }

    private void incrementContamination(int value){
        contamination_rate += value;
    }

    private void updateContaminationSlider(int value){
        contamination_slider.value = value;
        contamination_percent.text = value+"%";
    }

    private void incrementMoney(int value){
        money_counter += value;
    }

    private void updateMoney(int value){
        moneyUI.text = value.ToString();
    }

    private void elapseTime(int incResearchValue, int incContamiValue, int incMoneyValue){
        timer += Time.deltaTime;
        if(timer > day_duration){
            incrementResearchProgress(incResearchValue);
            updateResearchSlider(this.research_progress);
            incrementContamination(incContamiValue);
            updateContaminationSlider(this.contamination_rate);
            incrementMoney(incMoneyValue);
            incrementDays();
            updateMoney(this.money_counter);
            updateDays(this.days_counter);
            checkResearchers();
            timer = timer-day_duration;
        }
    }

    private void buyMedics(){
        if(local.getMedicPrice() <= this.money_counter){
            incrementMoney(-local.getMedicPrice());
            updateMoney(this.money_counter);
            local.addNewMedic();
        }
    }

    private void buyPManagers(){
        if(local.getPublicMPrice() <= this.money_counter){
            incrementMoney(-local.getPublicMPrice());
            updateMoney(this.money_counter);
            local.addNewPublicManager();
        }
    }

    private void buyResearchers(){
        if(local.getResearcherPrice() <= this.money_counter){
            incrementMoney(-local.getResearcherPrice());
            updateMoney(this.money_counter);
            local.addNewReasearcher();
        }
    }

    private void buyInfluencers(){
        if(local.getInfluencerPrice() <= this.money_counter){
            incrementMoney(-local.getInfluencerPrice());
            updateMoney(this.money_counter);
            local.addNewInfluencer();
        }
    }    

    private void checkEndGame(){
        if(this.contamination_rate >= 100)
            endGame("Defeat");
        else if(this.research_progress >= 100)
            endGame("Victory");
    }

    private void endGame(string ending){
        gameScreen.enabled = false;
        endGameScreen.enabled = true;
        if(ending.Equals("Defeat"))
            defeatScreen.SetActive(true);
        else if(ending.Equals("Victory"))
            victoryScreen.SetActive(true);
    }

    private void startGame(){
        print("começando jogo");
        endGameScreen.enabled = false;
        defeatScreen.SetActive(false);
        victoryScreen.SetActive(false);
    
        timer = 0.0f;
        day_duration = 3.0f;
        days_counter = 0;
        money_counter = 0;
        research_progress = 0;
        contamination_rate = 0;   

        incResearchValue = 0;
        incContamiValue = 0; 
        incMoneyValue = 100;

        updateContaminationSlider(contamination_rate);
        updateResearchSlider(research_progress);
        updateDays(days_counter);
        updateMoney(money_counter);
        local.initializeAll();
        this.gameObject.GetComponent<eventTriggerScript>().initializeEvents();
        startedFlag = true;
        mainMenu.enabled = false;
    }

    public void activateEvent(int id){
        eventName.text = this.GetComponent<eventTriggerScript>().eventsList[id].event_name;
        eventDescription.text = this.GetComponent<eventTriggerScript>().eventsList[id].event_description;
    }

    public void checkResearchers(){;
        if(local.getResearcherCount() == lastResearcherCounter+2){
            incResearchValue++;
            lastResearcherCounter += 2;
        }
    }

    public void pauseGame(){
        Time.timeScale = 0;
    }

    public void resumeGame(){
        Time.timeScale = 1;
    }
}
