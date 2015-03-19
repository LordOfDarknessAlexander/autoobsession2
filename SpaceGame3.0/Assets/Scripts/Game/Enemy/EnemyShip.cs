using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShip : Ship
{
    public GameData m_GData;

    public int m_SalvageVal;

    public void Awake()
    {
        SetBaseStats();
    }

    public void SetBaseStats()
    {
        this.m_Level = m_GData.m_Level;
        this.m_Tier = m_GData.m_EnemyTier;

        this.m_SData.m_HasShield = m_GData.m_HasShield;

        this.m_SData.m_HP = m_GData.m_EnemyHP;
        this.m_SData.m_Shield = m_GData.m_EnemyShield;
        this.m_DamageModifier = m_DamageLevel * Constants.DEFAULT_UPGRADE_MODIFIER;

        this.m_EngineLevel = m_GData.m_EnemyEngineLevel;
        this.m_DamageLevel = m_GData.m_EnemyDamageLevel;
        this.m_HealthLevel = m_GData.m_EnemyHealthLevel;
        this.m_ShieldLevel = m_GData.m_EnemyShield;
        this.m_SalvageVal = m_GData.m_SalvageVal * m_Tier;
    }

    private void DropLoot()
    {
        //go through engines, drop if random number > mDropChance
        foreach (EngineData engine in m_SData.m_Engines)
        {
            if (Random.value >= Constants.DROP_CHANCE)
            {
                Debug.Log("You dropped an item from the engines");
            }
        }

        //go through weapons, drop if random number > mDropChance
        foreach (Weapon weapon in m_SData.m_Weapons)
        {
            if (Random.value >= Constants.DROP_CHANCE)
            {
                Debug.Log("You dropped an item from the Weapons");
            }
        }
    }
}
