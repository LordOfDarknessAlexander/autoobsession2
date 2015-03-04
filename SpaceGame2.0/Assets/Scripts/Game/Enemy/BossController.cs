using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossController : Enemy 
{
    public Slider m_HealthValue;

    public GameObject m_Target;

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

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Instantiate(m_ShipController.m_Explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}