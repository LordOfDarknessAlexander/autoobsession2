using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    public GameData m_GData;
    public PlayerData m_PData;

    public float m_ForwardAccel;
    public int m_Damage = 1;

    private int damageModifier_;

    // Use this for initialization
    void Start()
    {
        damageModifier_ = 1;
        m_Damage = 1 * damageModifier_;
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
        if (gameObject.transform.position.y < -20 || gameObject.transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }
}
