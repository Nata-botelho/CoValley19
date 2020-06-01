﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerScript : MonoBehaviour
{
    private int days_counter;
    private int research_progress;
    private int contamination_rate;
    private List<skillTreeScript> skill_tree;
    private List<eventScript> events_list;
    private localScript local;

    public controllerScript(localScript _local){
        this.local = _local;
    }

    private void Start() {
        days_counter = 0;
        research_progress = 0;
        contamination_rate = 0;    
        skill_tree = new List<skillTreeScript>();
        events_list = new List<eventScript>();
    }

    private void Update() {
        
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
        this.days_counter += 1;
    }

    public void incrementResearchProgress(int value){
        this.research_progress += value;
    }

    public void incrementContaminationRate(int value){
        this.contamination_rate += value;
    }
}