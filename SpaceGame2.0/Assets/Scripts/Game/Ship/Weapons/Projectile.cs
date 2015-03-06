using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{

    public float m_ForwardAccel;
    public int m_Damage = 1;

    private int shipMultiplier_;
    private float lifeTime_ = 0.5f;

    // Use this for initialization
    void Start()
    {
        //shipMultiplier_ = 2;
        //m_Damage = 1 * shipMultiplier_;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.up * m_ForwardAccel;

        OnExit();
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
        if (gameObject.transform.position.y < -10 || gameObject.transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
