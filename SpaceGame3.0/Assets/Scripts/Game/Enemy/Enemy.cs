using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    public ShipController m_ShipController;
    public ShipData m_ShipData;
    public GameObject m_Target;

    public int m_SalvageVal;

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void Update();
}
