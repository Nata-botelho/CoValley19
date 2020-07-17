using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerScript : MonoBehaviour
{
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

    private List<skillTreeScript> skill_tree;
    private eventScript events;
    private localScript local;
    private playerScript player;

    public controllerScript(localScript _local, playerScript _player){
        this.local = _local;
        this.player = _player;
    }

    private void Start() {
        contamination_slider = GameObject.Find("Contam.Slider").GetComponent<Slider>();
        contamination_percent = GameObject.Find("Contam.Percent").GetComponent<Text>();
        research_slider = GameObject.Find("Research.Slider").GetComponent<Slider>();
        research_percent = GameObject.Find("Research.Percent").GetComponent<Text>();
        daysUI = GameObject.Find("DaysCounter").GetComponent<Text>();
        moneyUI = GameObject.Find("MoneyCounter").GetComponent<Text>();
    
        timer = 0.0f;
        day_duration = 5.0f;
        days_counter = 0;
        money_counter = 0;
        research_progress = 0;
        contamination_rate = 0;    

        updateContaminationSlider(contamination_rate);
        updateResearchSlider(research_progress);
        updateDays(days_counter);
        updateMoney(money_counter);
    }

    private void Update() {
        elapseTime();
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

    //FUNCTIONS
    private void incrementDays(){
        days_counter += 1;
    }

    private void updateDays(int value){
        daysUI.text = value.ToString();
    }

    public void incrementResearchProgress(int value){
        research_progress += value;
    }

    private void updateResearchSlider(int value){
        research_slider.value = value;
        research_percent.text = value+"%";
    }

    public void incrementContaminationRate(int value){
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

    private void elapseTime(){
        timer += Time.deltaTime;
        if(timer > day_duration){
            incrementResearchProgress(1);
            updateResearchSlider(this.research_progress);
            incrementContaminationRate(1);
            updateContaminationSlider(this.contamination_rate);
            incrementMoney(100);
            incrementDays();
            updateMoney(this.money_counter);
            updateDays(this.days_counter);
            timer = timer-day_duration;
        }
    }
}
