using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsc2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleTrigger()
    {
        Debug.Log("asd");
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("asd");
        Destroy(gameObject);
    }
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("asd");
        Destroy(gameObject);
    }
}
