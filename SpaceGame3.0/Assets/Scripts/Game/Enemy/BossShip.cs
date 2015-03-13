using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossShip : Ship 
{

    public void ChangeSpirte()
    {
        this.GetComponent<SpriteRenderer>().sprite = m_Sprites[m_Tier - 1];
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
