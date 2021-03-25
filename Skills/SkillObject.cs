using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : MonoBehaviour
{
    public string skillName;
    public Sprite sprite;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15,30,45)*Time.deltaTime);
    }
    public void SkillTaken(){
        gameObject.GetComponent<MeshRenderer>().enabled=false;
        gameObject.GetComponent<SphereCollider>().enabled=false;
        StartCoroutine(reActive());
    }
    IEnumerator reActive(){

        yield return new WaitForSeconds(7);

        gameObject.GetComponent<MeshRenderer>().enabled=true;
        gameObject.GetComponent<SphereCollider>().enabled=true;
    }
}
