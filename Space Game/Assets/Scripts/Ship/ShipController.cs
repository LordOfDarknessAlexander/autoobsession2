using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour 
{
    public Slider m_HealthValue;

    public ShipData m_Data;
    public GameObject m_Explosion;

    public float m_DropChance = 0.5f;


    //private float explosionLifetime_ = 2.0f;

    public void FireWeapons(string collisionLayerName)
    {
        for (int i = 0; i < m_Data.m_WeaponState.Length; ++i)
        {
            if (m_Data.m_WeaponState[i].m_CooldownTimer <= 0.0f)
            {
                m_Data.m_Weapons[i].Fire(m_Data.m_WeaponState[i], gameObject, collisionLayerName);
            }
        }
    }
    
    public void ApplyDamage(GameObject ship, int damage)
    {
        m_Data.m_HP -= damage;
        
        if (m_Data.m_HP <= 0)
        {
            Instantiate(m_Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            //DropLoot();
        }
        else
        {
            m_Data.m_HP -= damage;
        }
    }


    private void DropLoot()
    {
        //go through engines, drop if random number > mDropChance
        foreach(EngineData engine in m_Data.m_Engines)
        {
            if (Random.value >= m_DropChance)
            {
                GameObject newEngine = ObjectPool.Instance.GetObjectForType(engine.name, false);
                newEngine.transform.position = transform.position;
            }
        }

        //go through weapons, drop if random number > mDropChance
    }
}
