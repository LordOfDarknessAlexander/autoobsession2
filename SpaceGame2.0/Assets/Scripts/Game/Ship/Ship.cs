using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public ShipData m_Data;
    public ShipController m_ShipController;
    public GameObject m_Explosion;
    public GameObject m_Target;

    public int m_Health;
    public int m_DamageMultiplier;
}
