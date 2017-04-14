using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDespawn : MonoBehaviour {
    public int HP = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Zombie")
        {
            //Debug.Log(other.gameObject);
            HP -= other.GetComponent<ZombieNPC>().dmg;
            other.GetComponent<ZombieNPC>().PlayDestroy();
        }
    }
    
}
