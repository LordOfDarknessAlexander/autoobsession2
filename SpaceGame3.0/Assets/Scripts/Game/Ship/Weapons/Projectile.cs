using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    public float m_ForwardAccel;
    public int m_Damage;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.up * m_ForwardAccel;
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

    /*public void OnExit()
    {
        if (gameObject.transform.position.y < -30 || gameObject.transform.position.y > 30)
        {
            Destroy(gameObject);
        }
    }*/

    //get the modifier of the parebt ship to add to the damage of the projectile
    public int DamageToApply(GameObject parentShip)
    {
        m_Damage = 1 * parentShip.GetComponent<Ship>().m_DamageModifier;

        return m_Damage;
    }
}
