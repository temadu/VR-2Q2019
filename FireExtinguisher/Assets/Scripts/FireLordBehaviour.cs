using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLordBehaviour : MonoBehaviour
{

    public GameObject fire;
    public List<GameObject> createdFire;
    public int initialLag = 1;
    private float maybeFire;
    private bool once;
    // Start is called before the first frame update
    void Start()
    {
        once = false;
    }

    void FixedUpdate()
    {
        if (initialLag > 0)
        {
            initialLag--;
        }
        else if (!once) {
            once = true;
            GameObject[] flamables = GameObject.FindGameObjectsWithTag("Flamable");
            int rand = Random.Range(0, flamables.Length);
            createdFire = new List<GameObject>();
            createdFire.Add(Instantiate(fire, flamables[rand].transform));
            float height = flamables[rand].GetComponent<MeshCollider>().bounds.size.y;
            createdFire[0].transform.position = flamables[rand].transform.position + new Vector3(0, height + 0.2F, 0);
        }
    }

}
