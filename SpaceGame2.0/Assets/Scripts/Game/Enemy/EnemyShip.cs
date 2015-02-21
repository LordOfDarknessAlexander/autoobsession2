using UnityEngine;
using System.Collections;

public class EnemyShip : Ship 
{

	// Use this for initialization
    public override void ApplyDamage(GameObject ship, int damage)
    {
        if (m_Data.m_HP <= 0)
        {
             if (ship.name == "PlayerShip")
            {
                Instantiate(m_Explosion, transform.position, transform.rotation);
                Destroy(gameObject);
                DropLoot();
            }
        }
        else
        {
            if (ship.name == "PlayerShip")
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

    private void DropLoot()
    {
        //go through engines, drop if random number > mDropChance
        /*foreach (EngineData engine in m_Eship.m_Engines)
        {
            if (Random.value >= m_DropChance)
            {
                Debug.Log("You dropped an item");
            }
        }*/

        //go through weapons, drop if random number > mDropChance
        /*foreach (Weapon weapon in m_Data.m_Weapons)
        {
            if (Random.value >= m_DropChance)
            {
                Debug.Log("You dropped an item");
            }
        }*/
    }
}
