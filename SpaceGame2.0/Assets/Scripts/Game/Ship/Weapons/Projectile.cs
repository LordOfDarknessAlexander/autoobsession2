using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{

    public float m_ForwardAccel;
    public int m_Damage;

    private int shipMultiplier_;

    // Use this for initialization
    void Start()
    {
        shipMultiplier_ = 2;
        m_Damage = 1 * shipMultiplier_;
    }

    void Update()
    {


    }

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
}
