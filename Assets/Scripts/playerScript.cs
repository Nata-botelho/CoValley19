using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    
    private string playerName;
    private Sprite avatar;
    private int money;
	private int popularity;
   
	public playerScript(string _name){
        playerName = _name;
    }


    //GETTERS
    public Sprite getFoto(){
        return this.avatar;
    }

    public int getPontos_dinheiro(){
        return this.money;
    }
	
	public int getPopularidade(){
        return this.popularity;
    }

   

    //SETTERS
    public void updatePontos_dinheiro(int value){
        this.money += value;
    }

    public void updatePopularidade(int value){
        this.popularity += value;
    }

    void Start() {
    
    }

}