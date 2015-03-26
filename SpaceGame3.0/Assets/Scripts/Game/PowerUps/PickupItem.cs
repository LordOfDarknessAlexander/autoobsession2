using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour 
{
    //public float m_Mass; //in kg


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(this.GetComponent<PowerUps>().m_IsStorable)
            {
               other.gameObject.GetComponent<ShipData>().m_Inventory.Add(gameObject);
               gameObject.SetActive(false);
            }
            else
            {
                this.GetComponent<PowerUps>().UseItem(other.gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
