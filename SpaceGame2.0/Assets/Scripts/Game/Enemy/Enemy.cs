using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    public int m_ScoreVal;

    public StateMachine m_StateMachine;
    public ShipController m_ShipController;
    public ShipData m_ShipData;
    public Ship m_Ship;

    public GameObject m_Target;

    public abstract void OnStateEntered();
    public abstract void OnStateExit();

    public abstract void StateUpdate();
    public abstract void StateGUI();
}
