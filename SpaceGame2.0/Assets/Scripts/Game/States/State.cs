using UnityEngine;
using System.Collections;


public abstract class State : MonoBehaviour 
{
    public StateMachine m_StateMachine;
    public ShipController m_ShipController;
    public ShipData m_Ship;


    public abstract void OnStateEntered();
    public abstract void OnStateExit();
    public abstract void StateUpdate();
    public abstract void StateGUI();
}

