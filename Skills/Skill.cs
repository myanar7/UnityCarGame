using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    //////////////////////////////////////////// 
    /*
    skillNames:
    -shield
    -missile
    -mine
    */     
    ///////////////////////////////////////////
    private string skillName;
    private Sprite sprite;
    
    public void SetValues(string skillName,Sprite sprite){
        this.skillName=skillName;
        this.sprite=sprite;
    }
    public string GetName()=>this.skillName;
    public Sprite GetSprite()=>this.sprite;
    public void skillEvent(){
        if(this.skillName.Equals("shield"))
            Debug.Log("Skill Controller calls the shield skill");
        else if(this.skillName.Equals("mine"))
            Debug.Log("Skill Controller calls the mine skill");
        else if(this.skillName.Equals("missile"))
            Debug.Log("Skill Controller calls the missile skill");
    }
}
