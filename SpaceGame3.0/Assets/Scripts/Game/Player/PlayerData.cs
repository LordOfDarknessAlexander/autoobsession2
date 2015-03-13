using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public static PlayerData m_PData;

    public int m_EnemiesKilledLifetime;
    public int m_TotalScore;
    public int m_WavesCompleted;
    public int m_Salvage;
    public int m_ShipTier;
    public int m_EngineUpgrade;
    public int m_DamageUpgrade;
    public int m_HealthUpgrade;
    public int m_ShieldUpgrade;

    public bool m_HasShield;

    public int m_HP;
    public int m_Shield;

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
    }


    public void Save()
    {
        if (!File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            Debug.Log("Creating file");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");
            PlayerData pData = new PlayerData();

            pData.m_EnemiesKilledLifetime = m_PData.m_EnemiesKilledLifetime;
            pData.m_WavesCompleted = m_PData.m_WavesCompleted;
            pData.m_Salvage = m_PData.GetComponent<PlayerController>().m_Salvage;
            pData.m_ShipTier = m_PData.GetComponent<Ship>().m_Tier;
            pData.m_EngineUpgrade = m_PData.GetComponent<PlayerShip>().EngineLevel;
            pData.m_ShieldUpgrade = m_PData.GetComponent<PlayerShip>().ShieldLevel;
            pData.m_HealthUpgrade = m_PData.GetComponent<PlayerShip>().HealthLevel;
            pData.m_DamageUpgrade = m_PData.GetComponent<PlayerShip>().DamageLevel;

            bf.Serialize(file, pData);
            file.Close();
        }
        else
        {
            Debug.Log("Saving to " + Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerData pData = new PlayerData();

            pData.m_EnemiesKilledLifetime = m_PData.m_EnemiesKilledLifetime;
            pData.m_WavesCompleted = m_PData.m_WavesCompleted;
            pData.m_Salvage = m_PData.GetComponent<PlayerController>().m_Salvage;
            pData.m_ShipTier = m_PData.GetComponent<Ship>().m_Tier;
            pData.m_EngineUpgrade = m_PData.GetComponent<PlayerShip>().EngineLevel;
            pData.m_ShieldUpgrade = m_PData.GetComponent<PlayerShip>().ShieldLevel;
            pData.m_HealthUpgrade = m_PData.GetComponent<PlayerShip>().HealthLevel;
            pData.m_DamageUpgrade = m_PData.GetComponent<PlayerShip>().DamageLevel;

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
            PlayerData pData = (PlayerData)bf.Deserialize(file);

            m_PData.m_EnemiesKilledLifetime = pData.m_EnemiesKilledLifetime;
            m_PData.m_WavesCompleted = pData.m_WavesCompleted;
            m_PData.m_Salvage = pData.m_Salvage;
            m_PData.m_ShipTier = pData.m_ShipTier;
            m_PData.m_EngineUpgrade = pData.m_EngineUpgrade;
            m_PData.m_ShieldUpgrade = pData.m_ShieldUpgrade;
            m_PData.m_HealthUpgrade = pData.m_HealthUpgrade;
            m_PData.m_DamageUpgrade = pData.m_DamageUpgrade;

            file.Close();
        }
        else
        {
            Debug.Log("Failed to load, file doesn't exist");
        }
    }
}