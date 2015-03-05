using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Canvas m_Win;
    public Canvas m_Lose;
    public UIControl m_UIControl;
    public Text m_LivesText;

    public GameObject[] m_Enemy;
    public GameObject m_Player;
    
    public int m_Lives = 3; //Number of lives the player has
    public int m_Score = 0; //Player's current score
    public int m_TotalScore;

    public bool restart_;
    public bool gameOver_;
    public bool quit_;

    private float numEnemies_;
    private GameObject[] enemy_;

     // Use this for initialization
    void Start()
    {
        m_Lose.enabled = false;
        m_Win.enabled = false;

        restart_ = false;
        gameOver_ = false;
        quit_ = false;
        SpawnPlayer();
        //StartCoroutine(WaveSpawner());
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

    /*IEnumerator WaveSpawner()
    {
        yield return new WaitForSeconds(m_StartDelay);

        while (!gameOver_)
        {
            m_WaveNum++;

            m_WaveText.text = m_WaveNum.ToString("F0");

            numEnemies_ = m_DefaultWaveSize; //* m_WaveNum;//enemy_.Length;

            for (int i = 0; i < numEnemies_; ++i)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-m_SpawnArea.x, m_SpawnArea.x), m_SpawnArea.y, m_SpawnArea.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(m_Enemy[i], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(m_SpawnDelay);
            }
            yield return new WaitForSeconds(m_WaveDelay);

            if(GameObject.FindGameObjectWithTag("Player") == null)
            {
                gameOver_ = true;
            }
            if(gameOver_)
            {
                restart_ = true;
                GameOver();
                break;
            }
        }
    }*/

    public void SpawnPlayer()
    {
        if(m_Lives > 0)
        {
            m_LivesText.text = m_Lives.ToString();

            Vector3 playerSpawn_ = new Vector3(0.0f, -5.0f, 0.0f);
            Quaternion spawnPlayerRotation = Quaternion.identity;
            Instantiate(m_Player, playerSpawn_, spawnPlayerRotation);
        }
        else if(m_Lives == 0)
        {
            gameOver_ = true;
            GameOver();
        } 
    }

    public void GameOver()
    {

        m_Lose.enabled = true;
        m_Lives--;
        //restart_ = true;
        //m_GameOverText.text = "Game Over!";
        //m_RestartText.text = "Press 'R' for Restart";
        //m_QuitToMenu.text = "Press 'Q' to return to Menu";
        //Application.LoadLevel("GameOver");
    }
   
    private void Respawn()
    {
        SpawnPlayer();
    }
	
	public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
        Debug.Log(Application.persistentDataPath);

        PlayerData pData = new PlayerData();

        pData.m_PlayerShipData = m_Player.GetComponent<PlayerController>().m_PlayerShip;
        pData.m_EnemiesKilledLifetime = m_UIControl.m_EnemiesKilledLifetime;
        pData.m_WavesCompleted = m_UIControl.m_WavesCompleted;

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
            
            m_Player.GetComponent<PlayerController>().m_PlayerShip = pData.m_PlayerShipData;
            m_UIControl.m_EnemiesKilledLifetime = pData.m_EnemiesKilledLifetime;
            m_UIControl.m_WavesCompleted = pData.m_WavesCompleted;
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
