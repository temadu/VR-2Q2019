using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExpandant : MonoBehaviour{
    private float maybeFire;

    // Start is called before the first frame update
    void Start(){

        maybeFire = 100; // 2 Seconds

    }

    // Update is called once per frame
    void FixedUpdate(){
        if (maybeFire > 0){
            maybeFire--;
        }else{
            maybeFire = 100;
            Collider[] posibleOnFireObjects = Physics.OverlapSphere( transform.position , 2F);
            foreach (var item in posibleOnFireObjects){
                if( Random.Range(0,3) > 0  && 
                    item.gameObject.GetInstanceID() != transform.parent.gameObject.GetInstanceID() && 
                    item.gameObject.tag == "Flamable" &&
                    item.transform.childCount == 0
                    ){
                        Debug.Log(item.name + item.GetInstanceID());
                        Debug.Log(transform.parent.gameObject.name + transform.parent.gameObject.GetInstanceID());
                    GameObject newFire = Instantiate(this.gameObject, item.gameObject.transform);
                    newFire.transform.position = item.transform.position;
                }
            }
        }    
    }
}
