using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public ShipData m_Data;
    public ShipController m_ShipController;

    public int m_DamageMultiplier = 1;
    public int m_Tier = 1;
}
