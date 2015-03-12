using UnityEngine;
using System.Collections;

public class EnemyShip : Ship
{
    public void SetBaseStats(LevelData level)
    {
        m_Type = 1;
        m_Tier = 1 * level.m_CurrLevel;
        
        gameObject.GetComponent<ShipData>().m_HP = 5;
    }

    private void DropLoot()
    {
        //go through engines, drop if random number > mDropChance
        foreach (EngineData engine in m_Data.m_Engines)
        {
            if (Random.value >= Constants.DROP_CHANCE)
            {
                Debug.Log("You dropped an item from the engines");
            }
        }

        //go through weapons, drop if random number > mDropChance
        foreach (Weapon weapon in m_Data.m_Weapons)
        {
            if (Random.value >= Constants.DROP_CHANCE)
            {
                Debug.Log("You dropped an item from the Weapons");
            }
        }
    }
}
