using UnityEngine;
using System.Collections;

public class EnemyController : Enemy 
{
    public ShipController m_Ship;
    public GameController m_Controller;

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
        /*if (m_ShipData.transform.position.y < -30)
        {
            gameObject.SetActive(false);
        }*/
    }

    public override void Update()
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
            Camera.main.GetComponent<GameController>().Respawn();
            //Destroy(other.gameObject);
            gameObject.SetActive(false);

       }
    }
}
