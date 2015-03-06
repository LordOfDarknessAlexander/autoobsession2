using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public SpawnPlayer m_PSpawn;
    public EnemySpawn m_ESpawn;

    public Canvas m_Win;
    public Canvas m_Lose;

    public UIControl m_UIControl;
    public Text m_LivesText;

    public int m_Lives = 3; //Number of lives the player has
    public int m_Score = 0; //Player's current score
    public int m_TotalScore; //For stat pruposes

    public bool restart_;
    public bool gameOver_;
    public bool quit_;

    // Use this for initialization
    void Awake()
    {
        Load();
        m_Lose.enabled = false;
        m_Win.enabled = false;

        restart_ = false;
        gameOver_ = false;
        quit_ = false;

        m_PSpawn.Spawn();
        m_ESpawn.AISpawn();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            Save();
        }
        if(restart_)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Application.LoadLevel("Start");
            }
        }
    }


    public void GameOver()
    {
        m_Lose.enabled = true;
        m_Lives--;
    }

    public void Win()
    {
        m_Win.enabled = true;
    }
   
	public void Save()
    {
        if (!File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            Debug.Log("Creating file");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");
            PlayerData pData = new PlayerData();

            pData.m_EnemiesKilledLifetime = m_UIControl.m_EnemiesKilledLifetime;
            pData.m_WavesCompleted = m_UIControl.m_WavesCompleted;

            bf.Serialize(file, pData);
            file.Close();
        }
        else
        {
            Debug.Log("Saving to " + Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerData pData = new PlayerData();

            pData.m_EnemiesKilledLifetime = m_UIControl.m_EnemiesKilledLifetime;
            pData.m_WavesCompleted = m_UIControl.m_WavesCompleted;
            pData.m_Salvage = m_PSpawn.m_Player.GetComponent<PlayerController>().m_Salvage;
            pData.m_ShipTier = m_PSpawn.m_Player.GetComponent<Ship>().m_Tier;
            pData.m_EngineUpgrade = m_PSpawn.m_Player.GetComponent<PlayerShip>().EngineLevel;
            pData.m_ShieldUpgrade = m_PSpawn.m_Player.GetComponent<PlayerShip>().ShieldLevel;
            pData.m_HealthUpgrade = m_PSpawn.m_Player.GetComponent<PlayerShip>().HealthLevel;
            pData.m_DamageUpgrade = m_PSpawn.m_Player.GetComponent<PlayerShip>().DamageLevel;

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

            m_UIControl.m_EnemiesKilledLifetime = pData.m_EnemiesKilledLifetime;
            m_UIControl.m_WavesCompleted = pData.m_WavesCompleted;
            m_PSpawn.m_Player.GetComponent<PlayerController>().m_Salvage = pData.m_Salvage;
            m_PSpawn.m_Player.GetComponent<Ship>().m_Tier = pData.m_ShipTier;
            m_PSpawn.m_Player.GetComponent<PlayerShip>().EngineLevel = pData.m_EngineUpgrade;
            m_PSpawn.m_Player.GetComponent<PlayerShip>().ShieldLevel = pData.m_ShieldUpgrade;
            m_PSpawn.m_Player.GetComponent<PlayerShip>().HealthLevel = pData.m_HealthUpgrade;
            m_PSpawn.m_Player.GetComponent<PlayerShip>().DamageLevel = pData.m_DamageUpgrade;

            file.Close();
        }
        else
        {
            Debug.Log("Failed to load, file doesn't exist");
        }
    }
}

[Serializable]
class PlayerData
{
    public int m_EnemiesKilledLifetime;
    public int m_TotalScore;
    public int m_WavesCompleted;
    public int m_Salvage;
    public int m_ShipTier;
    public int m_EngineUpgrade;
    public int m_DamageUpgrade;
    public int m_HealthUpgrade;
    public int m_ShieldUpgrade;
}
