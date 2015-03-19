using UnityEngine;
using System.Collections;

public class EnemyController : Enemy 
{

    public float m_MaxVel;
    public Vector3 m_CurrVel;

    public override void Awake()
    {
        //Set target for all enemies
        if (m_Target == null)
        {
            m_Target = GameObject.FindGameObjectWithTag("Player");//Camera.main.GetComponent<SpawnPlayer>().m_Player;
        }
    }

    public override void OnExit()
    {
        if (m_ShipData.transform.position.y < -30)
        {
            gameObject.SetActive(false);
        }
    }

    public override void Update()
    {
        //to move enemy around scene

        if (m_Target != null)
        {
            this.GetComponent<Rigidbody>().AddForce(-transform.up * m_ShipData.GetTotalThrustAccel());

            this.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, m_MaxVel);

            m_CurrVel = GetComponent<Rigidbody>().velocity;

            //m_ShipController.FireWeapons("EnemyProjectile");
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
            other.gameObject.SetActive(false);
            Camera.main.GetComponent<GameController>().Respawn();
            
            gameObject.SetActive(false);

       }
    }
}
