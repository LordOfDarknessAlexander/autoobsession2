using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //public Canvas UI;
    public Text m_LivesText;
    public Text m_WaveText;
    public Text m_RestartText;
    public Text m_GameOverText;
    public Text m_QuitToMenu;

    public Vector3 m_SpawnArea;
    public GameObject m_Enemy;
    
    public float m_DefaultWaveSize;
    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;
    public int m_WaveNum;

    private bool restart_;
    private bool gameOver_;
    private bool quit_;

    private float numEnemies_;
    //private GameObject[] enemy_;

     // Use this for initialization
    void Start()
    {
        restart_ = false;
        gameOver_ = false;
        quit_ = false;
        StartCoroutine(WaveSpawner());
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

    IEnumerator WaveSpawner()
    {
        yield return new WaitForSeconds(m_StartDelay);

        while (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            m_WaveNum++;

            m_WaveText.text = m_WaveNum.ToString("F0");

            numEnemies_ = m_DefaultWaveSize * m_WaveNum;//enemy_.Length;

            for (int i = 0; i < numEnemies_; ++i)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-m_SpawnArea.x, m_SpawnArea.x), m_SpawnArea.y, m_SpawnArea.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(m_Enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(m_SpawnDelay);
            }
            yield return new WaitForSeconds(m_WaveDelay);

            if(GameObject.FindGameObjectWithTag("Player") == null)
            {
                gameOver_ = true;
            }
            if(gameOver_)
            {
                GameOver();
                restart_ = true;
                break;
            }
        }
    }

    public void GameOver()
    {
        m_GameOverText.text = "Game Over!";
        m_RestartText.text = "Press 'R' for Restart";
        m_QuitToMenu.text = "Press 'Q' to return to Menu";
       // Application.LoadLevel("Lose");
    }


}