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
    void Start()
    {
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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
        Debug.Log(Application.persistentDataPath);

        PlayerData pData = new PlayerData();

        pData.m_EnemiesKilledLifetime = m_UIControl.m_EnemiesKilledLifetime;
        pData.m_WavesCompleted = m_UIControl.m_WavesCompleted;

        pData.m_PlayerShipData = m_PSpawn.m_Player.GetComponent<PlayerController>().m_PlayerShip;

        bf.Serialize(file, pData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerData pData = (PlayerData)bf.Deserialize(file);
            file.Close();

            m_PSpawn.m_Player.GetComponent<PlayerController>().m_PlayerShip = pData.m_PlayerShipData;
        }
    }
}

[Serializable]
class PlayerData
{
    public PlayerShip m_PlayerShipData;
    public int m_EnemiesKilledLifetime;
    public int m_TotalScore;
    public int m_WavesCompleted;
}
