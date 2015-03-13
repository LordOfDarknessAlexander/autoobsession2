using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text m_RestartText;

    public GameObject m_Player;
    public EnemySpawn m_ESpawn;

    public Canvas m_Win;
    public Canvas m_Lose;

    public UIControl m_UIControl;

    public int m_Level;

    public int m_Lives = 3; //Number of lives the player has
    public int m_Score = 0; //Player's current score
    public int m_TotalScore; //For stat pruposes
    public int m_Kills;
    public int m_Salvage;

    public int m_TempKills;
    public int m_TempScore;
    public int m_TempSalvage;
    public int m_TempWaveNum;

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

        m_Player.GetComponent<PlayerShip>().ChangeSpirte();
        m_ESpawn.AISpawn();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            Save();
        }

        if(Input.GetKey(KeyCode.C))
        {
            SoftSave();
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

        if(Input.GetKey(KeyCode.X))
        {
            m_Player.GetComponent<ShipController>().ApplyDamage(m_Player, 100);
            Respawn();
        }
    }

    public void Dead()
    {

    }

    public void GameOver()
    {
        m_Lose.enabled = true;
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
            pData.m_Salvage = m_Player.GetComponent<PlayerController>().m_Salvage;
            pData.m_ShipTier = m_Player.GetComponent<Ship>().m_Tier;
            pData.m_EngineUpgrade = m_Player.GetComponent<PlayerShip>().EngineLevel;
            pData.m_ShieldUpgrade = m_Player.GetComponent<PlayerShip>().ShieldLevel;
            pData.m_HealthUpgrade = m_Player.GetComponent<PlayerShip>().HealthLevel;
            pData.m_DamageUpgrade = m_Player.GetComponent<PlayerShip>().DamageLevel;

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
            m_Player.GetComponent<PlayerController>().m_Salvage = pData.m_Salvage;
            m_Player.GetComponent<Ship>().m_Tier = pData.m_ShipTier;
            m_Player.GetComponent<PlayerShip>().EngineLevel = pData.m_EngineUpgrade;
            m_Player.GetComponent<PlayerShip>().ShieldLevel = pData.m_ShieldUpgrade;
            m_Player.GetComponent<PlayerShip>().HealthLevel = pData.m_HealthUpgrade;
            m_Player.GetComponent<PlayerShip>().DamageLevel = pData.m_DamageUpgrade;

            file.Close();
        }
        else
        {
            Debug.Log("Failed to load, file doesn't exist");
        }
    }

    public void SoftSave()
    {
        m_TempScore = m_Score;
        Debug.Log("Saved Score = " + m_TempScore);
        m_TempKills = m_Kills;
        Debug.Log("Saved Kills = " + m_TempKills);
        m_TempSalvage = m_Salvage;
        Debug.Log("Saved Salvage = " + m_TempSalvage);
        m_TempWaveNum = Camera.main.GetComponent<EnemySpawn>().m_WaveNum;
        Debug.Log("Saved Wave =" + m_TempWaveNum);
    }

    public void ClearSoftSave()
    {
        m_TempScore = 0;
        m_TempKills = 0;
        m_TempSalvage = 0;
        m_TempWaveNum = 0;
    }

    public void LoadSoftSave()
    {
        m_Score = m_TempScore;
        m_TempKills = m_Kills;
        m_TempSalvage = m_Salvage;
        Camera.main.GetComponent<Waves>().m_CurrentWave = m_TempWaveNum;
    }
	
	public void Respawn()
    {
        if(m_Lives != 0)
        {
            restart_ = true;

            m_RestartText.text = "Press 'R' for Restart or 'Q' to Quit";


            if(restart_)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Camera.main.GetComponent<Waves>().RestartCurrentWave();
                }
                if(Input.GetKeyDown(KeyCode.Q))
                {
                    Application.LoadLevel("StarMap");
                }
            }
        }
        else
        {
            gameOver_ = true;
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
