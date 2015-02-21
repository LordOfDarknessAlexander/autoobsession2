using UnityEngine;
using System.Collections;

public class EnemyController : Enemy 
{
    public float m_DropChance = 0.5f;

    public EnemyShip m_Eship;

    public override void StateUpdate()
    {
        //to move enemy around scene
        rigidbody.AddForce(-transform.up * m_ShipData.GetTotalThrustAccel());

        if (m_Target != null)
        {
          m_Eship.FireWeapons("EnemyProjectile");
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
