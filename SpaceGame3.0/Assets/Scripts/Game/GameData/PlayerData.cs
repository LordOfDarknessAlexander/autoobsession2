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
    public int m_ShipTier;
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
    void Start()
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

        m_EnemiesKilledLifetime = 0;
        m_TotalScore = 0;
        m_WavesCompleted = 0;
        m_Salvage = 0;
        m_ShipTier = 1;
        m_EngineLevel = 1;
        m_DamageLevel = 1;
        m_HealthLevel = 1;
        m_ShieldLevel = 0;

        m_HasShield = false;

        m_HP = 5 * m_ShipTier * m_HealthLevel;
        m_Shield = 10 * m_ShipTier * m_ShieldLevel;
        m_DamageModifer = 1 * m_ShipTier * m_DamageLevel;
        m_EngineModifier = 1 * m_ShipTier * m_EngineLevel;
    }


    public void Save()
    {
        if (!File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            Debug.Log("Creating file");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");
            PlayerSave pData = new PlayerSave();

            pData.m_EnemiesKilledLifetime = m_PData.m_EnemiesKilledLifetime;
            pData.m_WavesCompleted = m_PData.m_WavesCompleted;
            pData.m_TotalScore = m_PData.m_TotalScore;
            pData.m_Salvage = m_PData.m_Salvage;
            pData.m_ShipTier = m_PData.m_ShipTier;
            pData.m_Shield = m_PData.m_Shield;
            pData.m_HP = m_PData.m_HP;
            pData.m_EngineLevel = m_PData.m_EngineLevel;
            pData.m_ShieldLevel = m_PData.m_ShieldLevel;
            pData.m_HealthLevel = m_PData.m_HealthLevel;
            pData.m_DamageLevel = m_PData.m_DamageLevel;
            pData.m_Items = m_PData.m_Items;

            bf.Serialize(file, pData);
            file.Close();
        }
        else
        {
            Debug.Log("Saving to " + Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerSave pData = new PlayerSave();

            pData.m_EnemiesKilledLifetime = m_PData.m_EnemiesKilledLifetime;
            pData.m_WavesCompleted = m_PData.m_WavesCompleted;
            pData.m_TotalScore = m_PData.m_TotalScore;
            pData.m_Salvage = m_PData.m_Salvage;
            pData.m_ShipTier = m_PData.m_ShipTier;
            pData.m_Shield = m_PData.m_Shield;
            pData.m_HP = m_PData.m_HP;
            pData.m_EngineLevel = m_PData.m_EngineLevel;
            pData.m_ShieldLevel = m_PData.m_ShieldLevel;
            pData.m_HealthLevel = m_PData.m_HealthLevel;
            pData.m_DamageLevel = m_PData.m_DamageLevel;
            pData.m_Items = m_PData.m_Items;

            bf.Serialize(file, pData);
            file.Close();
        }
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            Debug.Log("Loading");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerSave pData = (PlayerSave)bf.Deserialize(file);

            m_PData.m_EnemiesKilledLifetime = pData.m_EnemiesKilledLifetime;
            m_PData.m_WavesCompleted = pData.m_WavesCompleted;
            m_PData.m_TotalScore = pData.m_TotalScore;
            m_PData.m_Salvage = pData.m_Salvage;
            m_PData.m_ShipTier = pData.m_ShipTier;
            m_PData.m_HP = pData.m_HP;
            m_PData.m_Shield = pData.m_Shield;
            m_PData.m_EngineLevel = pData.m_EngineLevel;
            m_PData.m_ShieldLevel = pData.m_ShieldLevel;
            m_PData.m_HealthLevel = pData.m_HealthLevel;
            m_PData.m_DamageLevel = pData.m_DamageLevel;
            m_PData.m_Items = pData.m_Items;

            file.Close();
        }
        else
        {
            Debug.Log("Failed to load, file doesn't exist");
        }
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