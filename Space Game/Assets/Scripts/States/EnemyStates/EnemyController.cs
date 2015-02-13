using UnityEngine;
using System.Collections;

public class EnemyController : State 
{
    public ShipData m_Ship;
    public ShipController m_ShipController;

    public GameObject m_Target;
    public GameObject m_Explosion;

    public override void OnStateEntered()
    {

        if (m_Target == null)
        {
            m_Target = GameObject.FindGameObjectWithTag("Player");
        }

    }

    public override void OnStateExit()
    {
        if(m_Ship.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public override void StateUpdate()
    {
        //to move player around scene
        rigidbody.AddForce(-transform.up * m_Ship.GetTotalThrustAccel());


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
            Instantiate(m_Explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);

            
        }
    }

    public override void StateGUI()
    {
    }
}
