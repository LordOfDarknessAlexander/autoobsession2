using UnityEngine;
using System.Collections;

public class ShieldData : MonoBehaviour
{
    public Transform m_ShieldPos;

    public void SetShield(GameObject ship)
    {
        if(ship.GetComponent<ShipData>().m_HasShield)
        {
            if (ship.GetComponent<ShipData>().m_CurrShield > 0)
            {
                m_ShieldPos.GetComponent<Renderer>().enabled = true;
            }
        }
        else
        {
            m_ShieldPos.GetComponent<Renderer>().enabled = false;
        }
    }
}
