using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class skillController : MonoBehaviourPun
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMesh playerName;
    private GameObject skills;
    private GameObject skillButton;
    public GameObject weapon;
    private Skill newSkill;
    
    private Skill[] skillArray=new Skill[3];
    
    SkillObject dataOfSkillTaken;
    private void Start() {
        
    }
    
    
    [PunRPC]
    public void RPC_SetVehicleName(string playerName){
        gameObject.name=playerName;
        this.playerName.text=gameObject.name;

    }

    void OnTriggerEnter(Collider collider){

        
        if(collider.CompareTag("Skill")){

            skills=collider.gameObject;     // Game Object which has this collider
            dataOfSkillTaken=(SkillObject)skills.GetComponent<SkillObject>();
            
           
           if(skillArray[2]==null && gameObject.CompareTag("Player")){
                newSkill=(Skill)ScriptableObject.CreateInstance<Skill>();
                newSkill.SetValues(dataOfSkillTaken.skillName,dataOfSkillTaken.sprite);

                skillArray=skillInsertion(skillArray);
           }
            dataOfSkillTaken.SkillTaken();
            
        }

    }
    private void OnTriggerExit(Collider collider) {
        if(collider.gameObject.name.Equals("EdgeOfTerrain") && photonView.IsMine){
            
            transform.position=GameObject.Find("Instantiate").GetComponent<InstantiateExample>().GiveAStartPosition().position;
            transform.rotation=Quaternion.identity;
        }    
    }
    public void OnClick_Replay(){
        transform.position=GameObject.Find("Instantiate").GetComponent<InstantiateExample>().GiveAStartPosition().position;
        transform.rotation=Quaternion.identity;
    }
    public void OnClick(){
        
        if(skillArray[0].GetName()=="missile")
            weapon.GetComponent<MissileController>().SpawnMissile();
        else if(skillArray[0].GetName()=="mine")
            weapon.GetComponent<MissileController>().SpawnMine();
        else if(skillArray[0].GetName()=="shield")
            weapon.GetComponent<MissileController>().SpawnShield();
        
        skillArray=skillUsage(skillArray);
        
    }

    Skill[] skillInsertion(Skill[] array){
        for(int i=0; i<array.Length;i++){
            if(array[i]==null){
                skillButton=GameObject.Find("SkillButton"+i);
                if(i==0)
                    skillButton.GetComponent<Button>().interactable=true;

                array[i]=newSkill;
                skillButton.GetComponent<Image>().overrideSprite=skillArray[i].GetSprite(); 
                break;
            }
        }
        return array;
    }
    Skill[] skillUsage(Skill[] array){

        if(array.Length!=0){
            array[0]=array[1];
            array[1]=array[2];
            array[2]=null;
        }

        for(int i=0; i<array.Length;i++){

            skillButton=GameObject.Find("SkillButton"+i);

            if(array[i]!=null){
                skillButton.GetComponent<Image>().overrideSprite=array[i].GetSprite(); 
            }else{
                skillButton.GetComponent<Image>().overrideSprite=null; 
            }
        }
        if(array[0]==null)
            GameObject.Find("SkillButton0").GetComponent<Button>().interactable=false;
        return array;
    }
}

