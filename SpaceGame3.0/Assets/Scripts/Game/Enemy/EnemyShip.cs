using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShip : Ship
{
    public int m_Tier;
    public int m_SalvageVal;

    public GameData m_GData;
    public ShieldData m_ShieldData;
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

        m_SData.m_HasShield = m_GData.m_HasShield;

        m_SData.m_HP = 2 * m_Level * m_Tier;
        m_SData.m_Shield = 5 * m_Level * m_Tier;
        m_DamageModifier = m_DamageLevel * Constants.DEFAULT_UPGRADE_MODIFIER;

        m_EngineLevel = m_GData.m_EnemyEngineLevel * m_Level * m_Tier;
        m_DamageLevel = m_GData.m_EnemyDamageLevel * m_Level * m_Tier;
        m_HealthLevel = m_GData.m_EnemyHealthLevel * m_Level * m_Tier;
        m_ShieldLevel = m_GData.m_EnemyShieldLevel * m_Level * m_Tier;
        m_SalvageVal = m_GData.m_SalvageVal * m_Level * m_Tier;
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
        int randNum = Random.Range(0, 100);

        if (randNum < 20)
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
        int randNum = Random.Range(0, 100);

        this.GetComponent<BossShip>().BossLootDrop(ship);

        if (randNum < 20)
        {
            m_ItemToDrop.LootDrop(ship);
        }
        else
        {
            return;
        }
    }
}
