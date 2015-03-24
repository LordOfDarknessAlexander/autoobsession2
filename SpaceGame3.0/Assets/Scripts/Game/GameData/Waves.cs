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

    public GameObject m_Player;

    public Vector3 m_SpawnArea;

	// Update is called once per frame
	public void Awake() 
    {
        m_Player = Camera.main.GetComponent<SpawnPlayer>().m_Player;
	}

    public IEnumerator WaveSpawner()
    {
        yield return new WaitForSeconds(m_StartDelay);

        while (Camera.main.GetComponent<EnemySpawn>().m_RequiredKills > 0)
        {
            for (int i = 0; i < Camera.main.GetComponent<EnemySpawn>().m_NumEnemiesInPool; ++i)
            {
                Debug.Log(Camera.main.GetComponent<EnemySpawn>().m_NumEnemiesInPool);

                Vector3 spawnPosition = new Vector3(Random.Range(-m_SpawnArea.x, m_SpawnArea.x), m_SpawnArea.y, m_SpawnArea.z);
                Quaternion spawnRotation = Quaternion.identity;

                Debug.Log(Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].ToString());

                Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].SetActive(true);
                Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].transform.position = spawnPosition;
                Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].transform.rotation = spawnRotation;

                yield return new WaitForSeconds(m_SpawnDelay);

            }
            yield return new WaitForSeconds(m_WaveDelay);


            if (m_Player == null)
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

            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                for (int i = 0; i < Camera.main.GetComponent<EnemySpawn>().m_NumEnemiesInPool; ++i)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-m_SpawnArea.x, m_SpawnArea.x), m_SpawnArea.y, m_SpawnArea.z);
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
                    Camera.main.GetComponent<EnemySpawn>().m_BossStatCanvas.enabled = false;
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