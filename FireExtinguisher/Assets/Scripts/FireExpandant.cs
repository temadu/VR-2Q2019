using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExpandant : MonoBehaviour
{
    private float maybeFire;

    public float radiusExpasion;

    // Start is called before the first frame update
    void Start(){
        maybeFire = 300; // 2 Seconds
        radiusExpasion = 4;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (maybeFire > 0){
            maybeFire--;
        } else {
            maybeFire = 300;
            Collider[] posibleOnFireObjects = Physics.OverlapSphere(transform.position, radiusExpasion);
            foreach (var item in posibleOnFireObjects) {
                if (Random.Range(0, 3) > 1 &&
                    item.gameObject.GetInstanceID() != transform.parent.gameObject.GetInstanceID() &&
                    item.gameObject.tag == "Flamable" &&
                    item.transform.childCount == 0
                    ) {
                    GameObject newFire = Instantiate(this.gameObject, item.gameObject.transform);
                    float height = item.GetComponent<MeshCollider>().bounds.size.y;
                    newFire.transform.position = item.transform.position + new Vector3(0, height + 0.2F, 0);
                }
            }
        }
    }

    void OnParticleTrigger(){
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
    }
    void OnParticleCollision(GameObject other){
        Destroy(gameObject);
    }
}
