using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MiniBossShip : EnemyShip
{
    public List<GameObject> m_BossDrops;

    private int randDrop_;

    new public void Awake()
    {
        SetMiniBossStats();
    }

    public void SetMiniBossStats()
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

    public void SetDrops()
    {
        randDrop_ = Random.Range(0, 101);

        if (randDrop_ <= 25)
        {
            //spawn health token
        }
        else if (randDrop_ > 25 && randDrop_ <= 50)
        {
            //spawn shield token
        }
        else if (randDrop_ > 50 && randDrop_ <= 75)
        {
            //spawn weapons token
        }
        else
        {
            //spawn engines token
        }
    }

}
