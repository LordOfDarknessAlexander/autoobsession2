using UnityEngine;
using System.Collections;

public class EnemyController : Enemy 
{
    
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
        //to move enemy around scene
        GetComponent<Rigidbody>().AddForce(-transform.up * m_ShipData.GetTotalThrustAccel());

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
            Instantiate(m_Ship.m_Explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
       }
    }

    public override void StateGUI()
    {
    }

   
}
