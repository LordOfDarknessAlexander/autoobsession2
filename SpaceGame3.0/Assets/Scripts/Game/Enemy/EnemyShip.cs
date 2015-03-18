using UnityEngine;
using System.Collections;

public class EnemyShip : Ship
{
    public GameData m_GData;

    public Sprite[] m_Sprites;

    public EnemyController m_EController;
    public LevelData m_LData;

    public void SetStats()
    {
        m_Type = m_GData.m_EnemyType;
        m_Tier = m_GData.m_EnemyTier;

        this.m_DamageModifier = 1 * m_Type * m_Tier;
        this.m_Data.m_HP = 5 * m_Type * m_Tier;        
    }

    public void ChangeShip()
    {
       //this.GetComponent<SpriteRenderer>().sprite = m_Sprites[m_Tier * m_Type - 1];
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
