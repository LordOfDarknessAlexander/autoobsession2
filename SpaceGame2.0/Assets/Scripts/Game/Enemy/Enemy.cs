using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    public StateMachine m_StateMachine;
    public ShipController m_ShipController;
    public ShipData m_ShipData;

    public abstract void OnEnter();
    public abstract void OnExit();

    public abstract void Update();


}
