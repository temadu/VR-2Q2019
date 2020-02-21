using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLordBehaviour : MonoBehaviour
{

    public GameObject firePrefab;
    public List<GameObject> createdFire = new List<GameObject>();
    public string flammableTag;
    public float initialLag = 5f;
    private float maybeFire;
    private bool once;
    // Start is called before the first frame update
    void Start()
    {
        once = false;
    }

    void FixedUpdate() {
      if(flammableTag != null && firePrefab != null && !once 
        && GameObject.FindGameObjectsWithTag("Fire").Length == 0){
        once = true;
        Invoke("StartFires", initialLag);
      }
    }
  public void Initialize(string tag, GameObject firePrefab){
    this.firePrefab = firePrefab;
    this.flammableTag = tag;
  }
  private void StartFires(){
    createdFire.Clear();
    GameObject[] flamables = GameObject.FindGameObjectsWithTag(flammableTag);
    int rand = Random.Range(0, flamables.Length);
    // createdFire = new List<GameObject>();
    createdFire.Add(Instantiate(firePrefab, flamables[rand].transform));
    float height = flamables[rand].GetComponent<MeshCollider>().bounds.size.y;
    createdFire[0].transform.position = flamables[rand].transform.position + new Vector3(0, height + 0.2F, 0);
    once = false;
  }
}
