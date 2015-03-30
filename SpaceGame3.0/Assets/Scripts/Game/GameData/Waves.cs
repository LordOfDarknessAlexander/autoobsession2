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

    public Text m_Control;

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
            m_Control.text = "";

            for (int i = 0; i < Camera.main.GetComponent<EnemySpawn>().enemyPool_.Count; ++i)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-m_SpawnArea.x, m_SpawnArea.x), m_SpawnArea.y, m_SpawnArea.z);
                Quaternion spawnRotation = Quaternion.identity;

                Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].SetActive(true);
                if (Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].GetComponent<ShipData>().m_HasShield)
                {
                    Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].GetComponent<EnemyShip>().m_ShieldData.SetShield(Camera.main.GetComponent<EnemySpawn>().enemyPool_[i]);
                }
                Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].transform.position = spawnPosition;
                Camera.main.GetComponent<EnemySpawn>().enemyPool_[i].transform.rotation = spawnRotation;

                yield return new WaitForSeconds(m_SpawnDelay);

            }
            yield return new WaitForSeconds(m_WaveDelay);

            if (Camera.main.GetComponent<EnemySpawn>().m_RequiredKills == 0)
            {
                m_Control.text = "Next Wave";
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
                    Camera.main.GetComponent<GameController>().SoftSave(m_Player);
                    Camera.main.GetComponent<EnemySpawn>().m_BossStatCanvas.enabled = false;
                    Camera.main.GetComponent<EnemySpawn>().m_KillsPanel.alpha = 1;
                    Camera.main.GetComponent<GameController>().Win();
                }
            }
        }
    }


    public void RestartCurrentWave()
    {
        Camera.main.GetComponent<SpawnPlayer>().PlayerRespawn();

        Camera.main.GetComponent<GameController>().LoadSoftSave(m_Player);

        Camera.main.GetComponent<EnemySpawn>().m_WaveNum = Camera.main.GetComponent<GameController>().m_TempWaveNum;

        Camera.main.GetComponent<EnemySpawn>().AISpawn();
    }
}