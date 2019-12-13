using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeReleaser : MonoBehaviour
{
    ParticleSystem particleSystem;

    void Start() {
         particleSystem = GetComponent<ParticleSystem>();
         particleSystem.Stop();
    }

    void Update() {
      if(Input.GetMouseButton(0)|| OVRInput.Get(OVRInput.RawButton.RIndexTrigger)){
        particleSystem.Play();
      } else {
        particleSystem.Stop();
      }
    }
}
