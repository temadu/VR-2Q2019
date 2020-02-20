﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeReleaser : MonoBehaviour
{
    ParticleSystem particleSystem;

    public float raycastLength;

    void Start() {
         particleSystem = GetComponent<ParticleSystem>();
         particleSystem.Stop();
         raycastLength = 150f;
    }

    void Update() {
      if(Input.GetMouseButton(0)|| OVRInput.Get(OVRInput.RawButton.RIndexTrigger)){
        RaycastHit hit;
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * raycastLength, Color.green);
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward * raycastLength, out hit))
        {
          if (hit.collider.tag == "Fire")
          {
            Debug.Log("FIREKILLER");
            hit.collider.GetComponent<FireExpandant>().applyDamage();
            // Destroy(hit.collider.gameObject);
          }
        }
        particleSystem.Play();
      } else {
        particleSystem.Stop();
      }
    }
}
