using UnityEngine;
using System.Collections;

public class EnemyShip : Ship
{
    public float m_DropChance = 0.5f;

    private void DropLoot()
    {
        //go through engines, drop if random number > mDropChance
        foreach (EngineData engine in m_Data.m_Engines)
        {
            if (Random.value >= m_DropChance)
            {
                Debug.Log("You dropped an item from the engines");
            }
        }

        //go through weapons, drop if random number > mDropChance
        foreach (Weapon weapon in m_Data.m_Weapons)
        {
            if (Random.value >= m_DropChance)
            {
                Debug.Log("You dropped an item from the Weapons");
            }
        }
    }
}
