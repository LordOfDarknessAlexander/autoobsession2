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
    public SpawnPlayer m_PSpawn;
    public EnemySpawn m_ESpawn;
    public Waves m_Waves;

    public GameObject m_Player;

    public Canvas m_Win;
    public Canvas m_Lose;
    public Canvas m_BossStatCanvas;
    public Canvas m_MainUI;

    public UIControl m_UIControl;

    public int m_Level;

    public int m_Lives = 3; //Number of lives the player has
    public int m_Score = 0; //Player's current score
    public int m_TotalScore; //For stat pruposes
    public int m_Kills;
    public int m_Salvage;

    public List<GameObject> m_TempItems;

    public int m_TempKills;
    public int m_TempScore;
    public int m_TempSalvage;
    public int m_TempWaveNum;
    public int m_TempEnemiesKilledLifetime;
    public int m_TempTotalScore;
    public int m_TempWavesCompleted;
    public int m_TempShipLevel;
    public int m_TempEngineLevel;
    public int m_TempDamageLevel;
    public int m_TempHealthLevel;
    public int m_TempShieldLevel;

    public bool m_TempHasShield;

    public int m_TempHP;
    public int m_TempShield;
    public int m_TempDamageModifer;
    public int m_TempEngineModifier;

    public bool m_Restart;
    public bool m_GameOver;
    public bool m_Play;

    // Use this for initialization
    void Awake()
    {
        //m_BossStatCanvas.enabled = false;

        m_MainUI.enabled = true;

        m_Lose.enabled = false;
        m_Win.enabled = false;

        m_Restart = false;
        m_GameOver = false;
        m_Play = false;

        m_PSpawn.Spawn();
        m_Player = m_PSpawn.m_Player;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            m_GData.Save();
        }

        if(Input.GetKey(KeyCode.C))
        {
            SoftSave(m_Player);
        }

        if(!m_Play)
        {
            m_ControlText.text = "Press 'Z' to begin";

            if(Input.GetKey(KeyCode.Z))
            {
                m_Play = true;
                Play();
            }
        }

        if (m_Restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                m_ControlText.text = "";
                //m_Lives--;
                m_Restart = false;
                m_Waves.RestartCurrentWave();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                m_Restart = false;
                Application.LoadLevel("StarMap");
            }
        }

        if(Input.GetKey(KeyCode.X))
        {
            m_Player.GetComponent<ShipController>().ApplyDamage(m_Player, 100);
            //Respawn();
        }
    }

    public void Play()
    {
        if(m_Play)
        {
            m_ControlText.text = "";
            m_ESpawn.SetShipPrefab();
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
   
    public void SoftSave(GameObject player)
    {
        m_TempScore = m_Score;
        m_TempKills = m_Kills;
        m_TempSalvage = m_Salvage;
        m_TempWaveNum = m_ESpawn.m_WaveNum;

        m_TempHasShield = player.GetComponent<ShipData>().m_HasShield;

        m_TempHP = player.GetComponent<ShipData>().m_HP;
        m_TempShield = player.GetComponent<ShipData>().m_Shield;

        m_TempItems = player.GetComponent<ShipData>().m_Inventory;

        Debug.Log("Soft Save complete");
    }

    public void ClearSoftSave()
    {
        m_TempScore = 0;
        m_TempKills = 0;
        m_TempSalvage = 0;
        m_TempWaveNum = 0;
    }

    public void LoadSoftSave(GameObject player)
    {
        m_Score = m_TempScore;
        m_Kills = m_TempKills;
        m_Salvage = m_TempSalvage;
        m_ESpawn.m_WaveNum = m_TempWaveNum;

        player.GetComponent<ShipData>().m_HasShield = m_TempHasShield;

        player.GetComponent<ShipData>().m_HP = m_PData.m_HP;
        player.GetComponent<ShipData>().m_Shield = m_TempShield;

        player.GetComponent<ShipData>().m_Inventory = m_TempItems;

        Debug.Log("Soft Save Loaded");
    }
	
	public void Respawn()
    {
        m_Lives -= 1;

        if(m_Lives != 0)
        {
            m_ESpawn.DestroyAll();

            m_Restart = true;

            m_ControlText.text = "Press 'R' for Restart or 'Q' to Quit";
        }
        else
        {
            m_ESpawn.DestroyAll();

            m_MainUI.enabled = false;

            m_GameOver = true;
            GameOver();
        }
    }

    public void SetPlayerSave()
    {
        LoadSoftSave(m_Player);

        m_PData.m_EnemiesKilledLifetime += m_Kills;
        m_PData.m_TotalScore += m_Score;
        m_PData.m_Salvage += m_Salvage;
        m_PData.m_Items = m_PSpawn.m_Player.GetComponent<ShipData>().m_Inventory;

        m_GData.Save();
    }
}