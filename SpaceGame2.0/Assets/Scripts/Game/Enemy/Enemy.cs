using UnityEngine;
using System.Collections;

public class Enemy : State
{
    public ShipData m_ShipData;
    public EnemyShip m_ShipController;
    public GameObject m_Target;
    public GameObject m_Explosion;

    public int Health;
    public int m_ScoreVal;

    public override void OnStateEntered()
    {
        //Set target for all enemies
        if (m_Target == null)
        {
            m_Target = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public override void OnStateExit()
    {
        if (m_ShipData.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public override void StateUpdate()
    {
    }
    public override void StateGUI()
    {
    }
}
