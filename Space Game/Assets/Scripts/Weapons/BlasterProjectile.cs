using UnityEngine;
using System.Collections;

public class BlasterProjectile : MonoBehaviour 
{

    public float m_ForwardAccel;
    public int m_Damage = 1;
   // public float m_Lifetime = 10.0f; //in seconds
    //public float m_DeadTime = 10.0f;
    //private float lifeTimer_;

    //private bool isDead_;
    //private float emissionRate_;

	// Use this for initialization
	void Start () 
    {
       /* lifeTimer_ = 0.0f;
        isDead_ = false;*/
	}

    void Update()
    {
        //lifeTimer_ += Time.deltaTime;

        /*if(!isDead_ && lifeTimer_ > m_Lifetime)
        {
            ObjectPool.Instance.PoolObject(gameObject);
            isDead_ = true;
            GetComponent<CapsuleCollider>().enabled = false;
            lifeTimer_ -= m_Lifetime;
        }
        else if(isDead_ && lifeTimer_ > m_DeadTime)
        {
            isDead_ = false;
            GetComponent<CapsuleCollider>().enabled = true;
            lifeTimer_ = 0.0f;
            ObjectPool.Instance.PoolObject(gameObject);  
        }*/

    }

	// Update is called once per frame
	void FixedUpdate () 
    {
        rigidbody.velocity = transform.up * m_ForwardAccel;
	}

    void OnCollisionEnter(Collision collision)
    {
        ShipController hitShip = collision.gameObject.GetComponentInChildren<ShipController>();
        if (hitShip != null)
        {
            Destroy(gameObject);
            hitShip.ApplyDamage(hitShip.gameObject,  m_Damage);
        }
    }

}
