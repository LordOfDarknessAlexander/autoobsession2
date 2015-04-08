using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShip : Ship
{
    public int m_Tier;
    public int m_SalvageVal;
    public int m_ScoreVal;

    public GameData m_GData;
    public LootTable m_ItemToDrop;

    private int randNum_;

    public void Awake()
    {
        SetStats();
    }

    public void SetStats()
    {
        m_Level = m_GData.m_Level;
        m_Tier = m_GData.m_EnemyTier;

        m_SData.m_HP = 2 * m_Level * m_Tier;
        m_DamageModifier = m_DamageLevel * Constants.DEFAULT_UPGRADE_MODIFIER;

        m_EngineLevel = m_GData.m_EnemyEngineLevel * m_Level * m_Tier;
        m_DamageLevel = m_GData.m_EnemyDamageLevel * m_Level * m_Tier;
        m_HealthLevel = m_GData.m_EnemyHealthLevel * m_Level * m_Tier;
        m_ShieldLevel = m_GData.m_EnemyShieldLevel * m_Level * m_Tier;
        m_SalvageVal = 50 * m_Level * m_Tier;

        if(m_ShieldLevel == 1)
        {
            m_SData.m_HasShield = false;
        }
        else
        {
            m_SData.m_HasShield = true;
            m_SData.m_Shield = 5 * m_Level * m_Tier;
        }

    }
    public int InventorySize
    {
        get
        {
            return (Constants.BASE_ENEMY_INVO_SIZE * (m_Level * m_Tier));
        }
    }

    public void DropLootEnemy(GameObject ship)
    {
        randNum_ = Random.Range(0, 100);

        if (randNum_ < 20)
        {
            m_ItemToDrop.LootDrop(ship);
        }
        else
        {
            return;
        }
    }

    public void DropLootBoss(GameObject ship)
    {
        randNum_ = Random.Range(0, 100);

        this.GetComponent<BossShip>().BossLootDrop(ship);

        if (randNum_ < 20)
        {
            m_ItemToDrop.LootDrop(ship);
        }
        else
        {
            return;
        }
    }
}
