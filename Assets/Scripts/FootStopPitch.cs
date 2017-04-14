using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStopPitch : MonoBehaviour
{
    AudioSource aus;
   
    // Use this for initialization
    void Start()
    {
       
        aus = GetComponents<AudioSource>()[1];
        aus.pitch += Random.Range(-0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
   
