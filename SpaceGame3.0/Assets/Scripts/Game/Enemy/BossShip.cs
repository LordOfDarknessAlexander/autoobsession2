using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossShip : EnemyShip 
{
    new public void Awake()
    {
        SetBossStats();
    }

    public void SetBossStats()
    {
        m_Level = m_GData.m_Level;
        m_Tier = m_GData.m_EnemyTier;

        m_SData.m_HasShield = m_GData.m_HasShield;

        m_SData.m_HP = 10 * m_Level * m_Tier;
        m_SData.m_Shield = 5 * m_Level * m_Tier;
        m_DamageModifier = m_DamageLevel * Constants.DEFAULT_UPGRADE_MODIFIER;

        m_EngineLevel = m_GData.m_EnemyEngineLevel * m_Level * m_Tier;
        m_DamageLevel = m_GData.m_EnemyDamageLevel * m_Level * m_Tier;
        m_HealthLevel = m_GData.m_EnemyHealthLevel * m_Level * m_Tier;
        m_ShieldLevel = m_GData.m_EnemyShieldLevel * m_Level * m_Tier;
        m_SalvageVal = m_GData.m_SalvageVal * m_Level * m_Tier;
    }
}
