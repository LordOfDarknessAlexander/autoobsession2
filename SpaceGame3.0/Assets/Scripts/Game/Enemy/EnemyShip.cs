using UnityEngine;
using System.Collections;

public class EnemyShip : Ship
{
    public EnemyController m_EController;

    public void SetStats(LevelData level)
    {
        //m_Type = level.m_CurrLevel;
        //m_Tier = level.m_CurrLevel;
        
        gameObject.GetComponent<ShipData>().m_HP = 5;
    }

    public void ChangeSpirte()
    {
       this.GetComponent<SpriteRenderer>().sprite = m_Sprites[m_Tier * m_Type - 1];
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
