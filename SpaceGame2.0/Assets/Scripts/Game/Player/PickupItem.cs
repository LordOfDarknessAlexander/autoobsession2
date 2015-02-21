using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour 
{
    public float mMass; //in kg
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           other.gameObject.GetComponent<ShipData>().AddItem(gameObject);  
        }
    }
}
