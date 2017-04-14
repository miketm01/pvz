using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNPC : MonoBehaviour {
    public int HP;
    public float MovementSpeed;
    public int dmg;
    AudioSource aus0;

    // Use this for initialization
    void Start () {
        aus0 = GetComponents<AudioSource>()[0];

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        if (HP <= 0) PlayDestroy();
    }
    public void PlayDestroy()
    {
        aus0.Play();
        
        Destroy(gameObject, 0.5f);
    }
}
