using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossController : Enemy 
{
    public Slider m_HealthValue;
    public Slider m_ShieldSlider;

    public BossShip m_Ship;

    public override void OnEnter()
    {
        //Set target for all enemies
        if (m_Target == null)
        {
            m_Target = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public override void OnExit()
    {
        if (m_ShipData.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
	
    // Use this for initialization
    public override void Update()
    {
        //Boss will stay at top of play area until Destroyed moving only side to side
        GetComponent<Rigidbody>().AddForce(transform.right * m_ShipData.GetTotalVertAccel());

        //Attack player if there is one
        if (m_Target != null)
        {
            m_ShipController.FireWeapons("EnemyProjectile");
        }
        else
        {
            return;
        }
    }
}