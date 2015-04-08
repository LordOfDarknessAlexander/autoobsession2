using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    public float m_ForwardAccel;
    public int m_Damage = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.up * m_ForwardAccel;

        //OnExit();
    }

    void OnCollisionEnter(Collision collision)
    {
        ShipController hitShip = collision.gameObject.GetComponentInChildren<ShipController>();
        if (hitShip != null)
        {
            Destroy(gameObject);
            hitShip.ApplyDamage(hitShip.gameObject, m_Damage);
        }
    }

    public void OnExit()
    {
        if (gameObject.transform.position.y < -30 || gameObject.transform.position.y > 30)
        {
            Destroy(gameObject);
        }
    }
}
