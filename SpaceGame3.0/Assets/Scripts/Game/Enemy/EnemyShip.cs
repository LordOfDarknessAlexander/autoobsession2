using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShip : Ship
{
    public int m_Tier;

    public GameData m_GData;

    public int m_SalvageVal;

    public void Awake()
    {
        SetStats();
    }

    public void SetStats()
    {
        this.m_Level = m_GData.m_Level;
        this.m_Tier = m_GData.m_EnemyTier;

        this.m_SData.m_HasShield = m_GData.m_HasShield;

        this.m_SData.m_HP = 5 * m_Level * m_Tier;
        this.m_SData.m_Shield = 5 * m_Level * m_Tier;
        this.m_DamageModifier = m_DamageLevel * Constants.DEFAULT_UPGRADE_MODIFIER;

        this.m_EngineLevel = m_GData.m_EnemyEngineLevel * m_Level * m_Tier;
        this.m_DamageLevel = m_GData.m_EnemyDamageLevel * m_Level * m_Tier;
        this.m_HealthLevel = m_GData.m_EnemyHealthLevel * m_Level * m_Tier;
        this.m_ShieldLevel = m_GData.m_EnemyShieldLevel * m_Level * m_Tier;
        this.m_SalvageVal = m_GData.m_SalvageVal * m_Level * m_Tier;
    }
}
