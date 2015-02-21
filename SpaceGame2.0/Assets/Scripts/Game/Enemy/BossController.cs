using UnityEngine;
using System.Collections;

public class BossController : Enemy 
{
    public EnemyShip m_Eship;

	// Use this for initialization
    public override void StateUpdate()
    {
        //Boss will stay at top of play area until Destroyed
        rigidbody.AddForce(transform.right * m_ShipData.GetTotalVertAccel());

        //Attack player if there is one
        if (m_Target != null)
        {
            m_Eship.FireWeapons("EnemyProjectile");
        }
        else
        {
            return;
        }
    }


}
