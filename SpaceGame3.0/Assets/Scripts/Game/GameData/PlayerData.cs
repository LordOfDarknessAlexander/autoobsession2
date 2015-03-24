using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public static PlayerData m_PData;

    public List<GameObject> m_Items;

    public int m_EnemiesKilledLifetime;
    public int m_TotalScore;
    public int m_WavesCompleted;
    public int m_Salvage;
    public int m_ShipLevel;
    public int m_EngineLevel;
    public int m_DamageLevel;
    public int m_HealthLevel;
    public int m_ShieldLevel;

    public bool m_HasShield;

    public int m_HP;
    public int m_Shield;
    public int m_DamageModifer;
    public int m_EngineModifier;

    // Use this for initialization
    void Awake()
    {
        if (m_PData == null)
        {
            DontDestroyOnLoad(gameObject);
            m_PData = this;
        }
        else if(m_PData != null)
        {
            Destroy(gameObject);
        }

        this.m_EnemiesKilledLifetime = 0;
        this.m_TotalScore = 0;
        this.m_WavesCompleted = 0;
        this.m_Salvage = 0;
        this.m_ShipLevel = 1;
        this.m_EngineLevel = 1;
        this.m_DamageLevel = 1;
        this.m_HealthLevel = 1;
        this.m_ShieldLevel = 0;

        this.m_HasShield = false;

        this.m_HP = 5 * m_ShipLevel * m_HealthLevel;
        this.m_Shield = 10 * m_ShipLevel * m_ShieldLevel;
        this.m_DamageModifer = 1 * m_ShipLevel * m_DamageLevel;
        this.m_EngineModifier = 1 * m_ShipLevel * m_EngineLevel;
    }
}

[System.Serializable]
class PlayerSave
{
    public int m_EnemiesKilledLifetime;
    public int m_TotalScore;
    public int m_WavesCompleted;
    public int m_Salvage;
    public int m_ShipTier;
    public int m_EngineLevel;
    public int m_DamageLevel;
    public int m_HealthLevel;
    public int m_ShieldLevel;

    public int m_HP;
    public int m_Shield;

    public List<GameObject> m_Items;
}