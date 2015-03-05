using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour 
{
    public float m_Mass; //in kg


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           other.gameObject.GetComponent<ShipData>().AddItem(gameObject);  
        }
    }
}
