using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExpandant : MonoBehaviour
{
    private float startFireSeconds;
    private float startFireTimer = 0f;

    public float radiusExpasion;

    public Vector3 originalScale;
    public float life;

    private float secondsToKill;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start(){
        startFireSeconds = 5f; // 2 Seconds
        radiusExpasion = 2.5f;
        originalScale = this.transform.localScale;
        life = 1f;
        secondsToKill = 1f;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (startFireTimer > startFireSeconds){
            Collider[] posibleOnFireObjects = Physics.OverlapSphere(transform.position, radiusExpasion);
            foreach (var item in posibleOnFireObjects) {
                if (Random.Range(0, 6) > 1 &&
                    item.gameObject.GetInstanceID() != transform.parent.gameObject.GetInstanceID() &&
                    (item.gameObject.tag == "FlammableCubicle" || item.gameObject.tag == "FlammableLiving") &&
                    item.transform.childCount == 0
                    ) {
                    GameObject newFire = Instantiate(this.gameObject, item.gameObject.transform);
                    float height = item.GetComponent<MeshCollider>().bounds.size.y;
                    newFire.transform.position = item.transform.position + new Vector3(0, height + 0.2F, 0);
                    newFire.transform.localScale = new Vector3(1f,1f,1f);
                }
            }
            startFireTimer = 0f;
        }
        startFireTimer += Time.deltaTime;

        this.transform.localScale = originalScale * life;
        this.audio.volume = life;
        if(life <= 0.3){
          this.audio.volume = 0;
          Destroy(this.gameObject);
        }
    }

    public void applyDamage(){
      this.life -=  Time.deltaTime / secondsToKill; 
      // Debug.Log("Time " + Time.deltaTime + " " + (Time.deltaTime /this.secondsToKill) +" = LIFE " + this.life);
      // Debug.Log("applying damage " + this.life);
    }

    void OnDrawGizmosSelected(){
      // Draw a yellow sphere at the transform's position
      Gizmos.color = Color.yellow;
      Gizmos.DrawSphere(transform.position, radiusExpasion);
    }

    // void OnParticleTrigger(){
    // Debug.Log("Particle Trigger");
    //     // Destroy(gameObject);
    // }
    // private void OnTriggerEnter(Collider other){
    // Debug.Log("Particle Trigger Enter");
    //     // Destroy(gameObject);
    // }
    // void OnParticleCollision(GameObject other){
    // Debug.Log("Particle Collision");
    //     Destroy(gameObject);
    // }
}
