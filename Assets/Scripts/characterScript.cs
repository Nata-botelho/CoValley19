using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class characterScript : MonoBehaviour
{
	private string characterName;
	private int xp;
	private int health;
	private Sprite sprite;
	private List<Util.Effects> efeitos;
	private List<Util.Symptoms> sintomas;

	public characterScript(string _name, int _xp, int _health, Sprite _sprite){
		this.characterName = _name;
		this.xp = _xp;
		this.health = _health;
		this.sprite = _sprite;
	}

	public string getName(){
		return characterName;
	}
	public int getXp(){
		return xp;
	}
	public int getHealth(){
		return health;
	}
	public Sprite GetSprite(){
		return this.sprite;
	}

	/*public List<Util.Effects> getListEffects(){
        List<Util.Effects> copy = (List<Util.Effetcs>) Util.CopyArray(efeitos);
        return copy;
    }
	
    public List<Util.Symptoms> getListSymptoms(){
        List<Util.Symptoms> copy = (List<Util.Symptoms>) Util.CopyArray(sintomas);
        return copy;
    }*/
    public void setXP(int value){
    	xp = xp - value;
    }
    public void setHealth(int value){
    	health = health - value;
    }

    /**
    /* metodos para sobrescrever em cada classe, especificando simtomas ou efeitos
    */

    public void setSymptoms(List<Util.Effects> efeitos){

    }
    public void setEffects(List<Util.Symptoms> simtomas){

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
