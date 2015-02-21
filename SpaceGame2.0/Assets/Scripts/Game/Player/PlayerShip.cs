using UnityEngine;
using System.Collections;

public class PlayerShip : Ship 
{

    public override void ApplyDamage(GameObject ship, int damage)
    {
        if (m_Data.m_HP <= 0)
        {
            if (ship.name == "EnemyShip")
            {
                Instantiate(m_Explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
            if (ship.name == "EnemyShip")
            {
                m_Data.m_HP -= damage;
            }
        }
    }

    public override void FireWeapons(string collisionLayerName)
    {
        for (int i = 0; i < m_Data.m_WeaponState.Length; ++i)
        {
            if (m_Data.m_WeaponState[i].m_CooldownTimer <= 0.0f)
            {
                m_Data.m_Weapons[i].Fire(m_Data.m_WeaponState[i], gameObject, collisionLayerName);
            }
        }
    }

}
