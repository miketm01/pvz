using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieSpawner : MonoBehaviour {
    public List<GameObject> SpawnPoints;
    public List<GameObject> TargetPoints;
    public GameObject ZombiePrefab;
    public int spawninterval;//between timed
    public int spawnRate; //how many zombies at time
    int framecount=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        framecount++;
        if (framecount>spawninterval)
        {
            spawnZombie();
            framecount = 0;
        }
	}

    void spawnZombie()
    {
        for(int i=1;i<=spawnRate;i++)
        {
           GameObject goZombie= Instantiate(ZombiePrefab, SpawnPoints[Random.Range(0, SpawnPoints.Count - 1)].transform.position,Quaternion.identity);
            goZombie.GetComponent<NavMeshAgent>().SetDestination(TargetPoints[Random.Range(0, TargetPoints.Count - 1)].transform.position);

        }
    }

    
}
