using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public ShipData m_Data;

    public List<Sprite> m_Sprites;

    public int m_DamageMultiplier;
    public int m_Tier;
    public int m_Type;

    public void SetBaseStats()
    {
        m_Tier = 1;
        m_Type = 1;
        gameObject.GetComponent<ShipData>().m_HP = 5;
    }

}
