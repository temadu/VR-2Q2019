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
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
