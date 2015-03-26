using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShip : Ship
{
    public int m_Tier;

    public GameData m_GData;
    public Items m_ItemList;

    private int randNum_;

    public void Awake()
    {
        SetStats();
        SetIventory();
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
    public void SetIventory()
    {
        m_SData.m_Inventory.Capacity = InventorySize;

        randNum_ = Random.Range(0, m_ItemList.m_PowerUps.Count);

        for(int j = 0; j < m_SData.m_Inventory.Capacity; ++j)
        {
            m_SData.m_Inventory.Add(m_ItemList.m_PowerUps[randNum_]);
        }
    }

    public void DropLoot(GameObject parentShip)
    {
        randNum_ = Random.Range(0, m_SData.m_Inventory.Count);

        Vector3 spawnPosition = new Vector3(parentShip.transform.position.x, parentShip.transform.position.y, 0);
        Quaternion spawnRotation = Quaternion.identity;

        for(int i = 0; i < m_SData.m_Inventory.Count; ++i)
        {
            Instantiate(m_SData.m_Inventory[i], spawnPosition, spawnRotation);
        }
    }
}
