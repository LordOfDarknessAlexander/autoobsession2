using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour 
{
    public float m_Mass; //in kg


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           other.gameObject.GetComponent<ShipData>().AddItem(gameObject);  
        }
    }
}
