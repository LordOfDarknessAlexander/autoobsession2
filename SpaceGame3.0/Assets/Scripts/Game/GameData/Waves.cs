using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpawnArea
{
    public float xMin, xMax, yMin, yMax;
}
public class Waves : MonoBehaviour 
{
    public GameObject m_Player;
    public SpawnArea m_SpawnBoundry;

    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;

    public int m_CurrentWave;

    //public Vector3 m_SpawnArea;

	// Use this for initialization
	void Start () 
    {
        //m_Player.GetComponent<SpriteRenderer>().enabled = true;
        Camera.main.GetComponent<EnemySpawn>().AISpawn();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public IEnumerator WaveSpawner()
    {
        while(GameObject.FindGameObjectWithTag("Player") != null)
        {
            yield return new WaitForSeconds(m_StartDelay);
       
            if(Camera.main.GetComponent<EnemySpawn>().m_RequiredKills > 0)
            {
                for (int i = 0; i < Camera.main.GetComponent<EnemySpawn>().m_NumEnemiesInPool; ++i)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(m_SpawnBoundry.xMin, m_SpawnBoundry.xMax), Random.Range(m_SpawnBoundry.yMin, m_SpawnBoundry.yMax), 0.0f);
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
            }
        
            if (Camera.main.GetComponent<EnemySpawn>().m_RequiredKills == 0)
            {
                Camera.main.GetComponent<EnemySpawn>().m_WaveNum++;
                Camera.main.GetComponent<EnemySpawn>().m_WaveText.text = Camera.main.GetComponent<EnemySpawn>().m_WaveNum.ToString("F0");
                Camera.main.GetComponent<GameController>().SoftSave();
                Camera.main.GetComponent<EnemySpawn>().AISpawn();
            }

            if (Camera.main.GetComponent<GameController>().gameOver_)
            {
                Camera.main.GetComponent<GameController>().restart_ = true;
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
                    Vector3 spawnPosition = new Vector3(Random.Range(m_SpawnBoundry.xMin, m_SpawnBoundry.xMax), m_SpawnBoundry.yMax, 0.0f);
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

                if (GameObject.FindGameObjectWithTag("Boss") != null)
                {
                    Camera.main.GetComponent<EnemySpawn>().m_WaveNum++;
                    Camera.main.GetComponent<EnemySpawn>().m_WaveText.text = Camera.main.GetComponent<EnemySpawn>().m_WaveNum.ToString("F0");
                    Camera.main.GetComponent<GameController>().SoftSave();
                    Camera.main.GetComponent<EnemySpawn>().AISpawn();
                }

                if (GameObject.FindGameObjectWithTag("Player") == null)
                {
                    StopAllCoroutines();
                    Camera.main.GetComponent<GameController>().Respawn();
                    break;
                }

                if (Camera.main.GetComponent<GameController>().gameOver_)
                {
                    Camera.main.GetComponent<GameController>().GameOver();
                    break;
                }

            }
        }
    }


    public void RestartCurrentWave()
    {
        Camera.main.GetComponent<SpawnPlayer>().Spawn();

        Camera.main.GetComponent<GameController>().LoadSoftSave();

        Camera.main.GetComponent<EnemySpawn>().m_WaveNum = m_CurrentWave;

        Camera.main.GetComponent<EnemySpawn>().AISpawn();
    }
}
