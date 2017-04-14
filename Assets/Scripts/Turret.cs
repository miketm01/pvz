using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public float rateOfFire;
    public int dmg;
    public int range;
    bool isOncooldown;
    public float CdTime = 0f;
   public List<GameObject> TargetList;
   public GameObject RadialMenu;
	// Use this for initialization
	void Start () {
        GetComponent<SphereCollider>().radius = range;
        TargetList = new List<GameObject>();
	}
    private void OnTriggerExit(Collider other)
    {
        TargetList.Remove(other.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {

       
        if (other.gameObject.tag == "Zombie")
        {
            TargetList.Add(other.gameObject);

        }
    }
    
 
    // Update is called once per frame
       

IEnumerator doDamage(GameObject other)
{
        if (isOncooldown) yield return 0;
        else 
        {
            other.GetComponent<ZombieNPC>().HP -= dmg;
            isOncooldown=true;
            CdTime = rateOfFire;
            GetComponent<LineRenderer>().SetPosition(1, other.transform.position);
            yield return new WaitForSeconds(rateOfFire);
            isOncooldown = false;

        }
     
}
void Update () {
        
        if (isOncooldown)
            CdTime -= Time.deltaTime;
        else CdTime = 0;

        if (TargetList.Count>0)
        {
            if (TargetList[0]!=null)
            {
                StartCoroutine(doDamage(TargetList[0]));
                Debug.DrawLine(transform.position, TargetList[0].transform.position, Color.red);
            }
        }


	}
    private void FixedUpdate()
    {
        if (TargetList!=null && TargetList.Count>0)
        foreach(GameObject go in TargetList)
        {
                if (go == null) { TargetList.Remove(go); break; }
        }
    }

    public void UITogleRadial()
    {
        //bool aux = RadialMenu.activeSelf;
        RadialMenu.SetActive(!RadialMenu.gameObject.activeSelf);
    }
    public void AddRange()
    {
        range += 1;
        GetComponent<SphereCollider>().radius = range;

    }
    public void SellMe()
    {

    }
    public void AddDmg()
    {
        dmg += 1;
    }

    public void FasterFire()
    {

        rateOfFire -= 0.1f;
    }
}
