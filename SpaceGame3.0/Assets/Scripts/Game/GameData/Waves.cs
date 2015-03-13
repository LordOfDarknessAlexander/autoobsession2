using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Waves : MonoBehaviour 
{
    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;
    
    public int m_CurrentWave;

    private int sPoint_;
    private int numKills_;
    private int numEnemies_;
    private GameObject player_;

    public GameObject m_SpawnPoints;
    public List<GameObject> m_SpawnPoint = new List<GameObject>();

	// Use this for initialization
	void Start () 
    {
        //for testing
        numEnemies_ = Camera.main.GetComponent<EnemySpawn>().m_NumEnemiesInPool;
        numKills_ = Camera.main.GetComponent<EnemySpawn>().m_RequiredKills;
        player_ = GameObject.FindGameObjectWithTag("Player");

        Camera.main.GetComponent<EnemySpawn>().AISpawn();
	}
	
	// Update is called once per frame
	void Update () 
    {
        RandomSpawnPoint();
	}

    public void RandomSpawnPoint()
    {
        sPoint_ = Random.Range(0, m_SpawnPoint.Count);
    }

    public IEnumerator WaveSpawner()
    {
        while (Camera.main.GetComponent<EnemySpawn>().m_RequiredKills > 0)
        {
            yield return new WaitForSeconds(m_StartDelay);
       
            if(Camera.main.GetComponent<EnemySpawn>().m_RequiredKills > 0)
            {
                for (int i = 0; i < Camera.main.GetComponent<EnemySpawn>().m_NumEnemiesInPool; ++i)
                {
                    Vector3 spawnPosition = new Vector3(0, 12, 0/*m_SpawnPoint[sPoint_].transform.position.x, 
                                                        m_SpawnPoint[sPoint_].transform.position.y,     
                                                        m_SpawnPoint[sPoint_].transform.position.z*/);
                    Quaternion spawnRotation = Quaternion.identity;

                    for (int j = 0; j < Camera.main.GetComponent<EnemySpawn>().enemyPool_.Count; ++j)
                    {
                        Camera.main.GetComponent<EnemySpawn>().enemyPool_[j].SetActive(true);
                        Camera.main.GetComponent<EnemySpawn>().enemyPool_[j].transform.position = spawnPosition;
                        Camera.main.GetComponent<EnemySpawn>().enemyPool_[j].transform.rotation = spawnRotation;
                    }
                    yield return new WaitForSeconds(m_SpawnDelay);
                }
                yield return new WaitForSeconds(m_WaveDelay);
            }

            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                Camera.main.GetComponent<GameController>().Respawn();
                break;
            }

            if (Camera.main.GetComponent<EnemySpawn>().m_RequiredKills == 0)
            {
                Camera.main.GetComponent<EnemySpawn>().m_WaveNum++;
                Camera.main.GetComponent<EnemySpawn>().m_WaveText.text = Camera.main.GetComponent<EnemySpawn>().m_WaveNum.ToString("F0");
                Camera.main.GetComponent<GameController>().SoftSave();
                Camera.main.GetComponent<EnemySpawn>().AISpawn();
            }

            if (Camera.main.GetComponent<GameController>().m_GameOver)
            {
                Camera.main.GetComponent<GameController>().m_Restart = true;
                Camera.main.GetComponent<GameController>().GameOver();
                break;
            }
        }
    }

    public IEnumerator BossSpawner()
    {

        while(GameObject.FindGameObjectWithTag("Boss") != null)
        {
            yield return new WaitForSeconds(m_StartDelay);

            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                for (int i = 0; i < Camera.main.GetComponent<EnemySpawn>().m_NumEnemiesInPool; ++i)
                {
                    Vector3 spawnPosition = new Vector3(m_SpawnPoint[sPoint_].transform.position.x, 
                                                        m_SpawnPoint[sPoint_].transform.position.y,     
                                                        m_SpawnPoint[sPoint_].transform.position.z);
                    Quaternion spawnRotation = Quaternion.identity;

                    for (int j = 0; j < Camera.main.GetComponent<EnemySpawn>().enemyPool_.Count; ++j)
                    {
                        Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].SetActive(true);
                        Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].transform.position = spawnPosition;
                        Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].transform.rotation = spawnRotation;
                    }
                    yield return new WaitForSeconds(m_SpawnDelay);
                }
                yield return new WaitForSeconds(m_WaveDelay);

                if (GameObject.FindGameObjectWithTag("Boss") == null)
                {
                    Camera.main.GetComponent<EnemySpawn>().m_WaveNum++;
                    Camera.main.GetComponent<EnemySpawn>().m_WaveText.text = Camera.main.GetComponent<EnemySpawn>().m_WaveNum.ToString("F0");
                    Camera.main.GetComponent<GameController>().SoftSave();
                    Camera.main.GetComponent<EnemySpawn>().m_BossStatCanvas.alpha = 0;
                    Camera.main.GetComponent<EnemySpawn>().m_KillsPanel.alpha = 1;
                    Camera.main.GetComponent<EnemySpawn>().AISpawn();
                }

                if (GameObject.FindGameObjectWithTag("Player") == null)
                {
                    StopAllCoroutines();
                    Camera.main.GetComponent<GameController>().Respawn();
                    break;
                }

                if (Camera.main.GetComponent<GameController>().m_GameOver)
                {
                    Camera.main.GetComponent<GameController>().GameOver();
                    break;
                }

            }
        }
    }


    public void RestartCurrentWave()
    {
        Camera.main.GetComponent<GameController>().LoadSoftSave();

        Camera.main.GetComponent<SpawnPlayer>().Spawn();

        Camera.main.GetComponent<EnemySpawn>().m_WaveNum = m_CurrentWave;

        Camera.main.GetComponent<EnemySpawn>().AISpawn();
    }
}
