using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text m_ControlText;

    public GameData m_GData;
    public PlayerData m_PData;

    public List<GameObject> playerPool = new List<GameObject>();

    public GameObject m_Player;
    public SpawnPlayer m_PSpawn;
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

    public bool m_Restart;
    public bool m_GameOver;
    public bool m_Play;

    // Use this for initialization
    void Awake()
    {
        m_Lose.enabled = false;
        m_Win.enabled = false;

        m_Restart = false;
        m_GameOver = false;
        m_Play = false;

        m_PSpawn.Spawn();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            m_PData.Save();
        }

        if(Input.GetKey(KeyCode.C))
        {
            SoftSave();
        }

        if(!m_Play)
        {
            m_ControlText.text = "Press 'S' to begin";

            if(Input.GetKey(KeyCode.S))
            {
                m_Play = true;
                Play();
            }
        }

        if(m_Restart)
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

        /*Debug.Log("Lives = " + m_Lives);
        Debug.Log("Salvage = " + m_Salvage);
        Debug.Log("Lifetime Kills = " + m_UIControl.m_EnemiesKilledLifetime);
        Debug.Log("Waves Completed = " + m_UIControl.m_WavesCompleted);
        Debug.Log("Shield Level = " + m_Player.GetComponent<PlayerShip>().ShieldLevel);
        Debug.Log("Engine Level =" + m_Player.GetComponent<PlayerShip>().EngineLevel);
        Debug.Log("Health Level =" + m_Player.GetComponent<PlayerShip>().HealthLevel);
        Debug.Log("Damage Level = " + m_Player.GetComponent<PlayerShip>().DamageLevel);*/
    }

    public void Play()
    {
        if(m_Play)
        {
            m_ControlText.text = "";
            m_ESpawn.AISpawn();
        }
    }

    public void GameOver()
    {
        m_Lose.enabled = true;
    }

    public void Win()
    {
        m_Win.enabled = true;
    }
   
    public void SoftSave()
    {
        m_TempScore = m_Score;
        //Debug.Log("Saved Score = " + m_TempScore);
        m_TempKills = m_Kills;
        //Debug.Log("Saved Kills = " + m_TempKills);
        m_TempSalvage = m_Salvage;
        //Debug.Log("Saved Salvage = " + m_TempSalvage);
        m_TempWaveNum = Camera.main.GetComponent<EnemySpawn>().m_WaveNum;
        //Debug.Log("Saved Wave =" + m_TempWaveNum);
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
            m_Restart = true;

            m_ControlText.text = "Press 'R' for Restart or 'Q' to Quit";


            if(m_Restart)
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
            m_GameOver = true;
        }
    }

    public void Player()
    {
        m_Player.GetComponent<Ship>().m_Tier = m_PData.m_ShipTier;
        

        GameObject obj = (GameObject)Instantiate(m_Player);
        obj.SetActive(false);
        playerPool.Add(obj);

    }
}