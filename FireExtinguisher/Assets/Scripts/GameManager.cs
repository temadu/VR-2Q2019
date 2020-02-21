using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject firePrefab;

    void Start()
    {
      GameObject player = GameObject.Find("OVRCameraRig");
      // GameObject player = GameObject.Find("RigidBodyFPSController");
      if(Random.Range(0.0f, 1.0f) > 0.5f){
        this.gameObject.AddComponent<FireLordBehaviour>().Initialize("FlammableLiving", firePrefab);
        player.transform.position = new Vector3(7.67f,0.65f,-1.08f);
      } else {
        this.gameObject.AddComponent<FireLordBehaviour>().Initialize("FlammableCubicle",firePrefab);
        player.transform.position = new Vector3(-3.9f,0.65f,-10.9f);
      }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
