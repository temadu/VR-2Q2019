using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firekiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            Debug.Log("CLICKING");
            RaycastHit hit;
            Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 100, Color.green);
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider.tag == "Fire")
                {
                  Debug.Log("FIREKILLER");
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
