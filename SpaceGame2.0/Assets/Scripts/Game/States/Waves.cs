using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Waves : MonoBehaviour 
{   
    public GameObject[] m_Enemies;
    public Text m_WaveText;

    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;

    public int m_RequiredKills;
    public int m_WaveNum;

    //private float numEnemies_;
    private List<GameObject> enemiesInWave_;

    public Vector3 m_SpawnArea;

    public GameController m_Controller;

    public void AISpawn()
    {
        if (m_WaveNum == 1)
        {
            //populate enemy array
            enemiesInWave_ = new List<GameObject>();
            enemiesInWave_.Add(m_Enemies[0]);
            //if play is active start spawning
            if(GameObject.FindGameObjectWithTag("Player") != null)
            {
                m_RequiredKills = 10;
                StartCoroutine(WaveSpawner());
            }
            //else do nothing
            else
            {
                return;
            }
        }

        if(m_WaveNum == 2)
        { 
            //populate enemy array
            //if play is active start spawning
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(WaveSpawner());
            }
            //else do nothing
            else
            {
                return;
            }
        }

        if(m_WaveNum == 3)
        {
            //populate enemy array
            //if play is active start spawning
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(WaveSpawner());
            }
            //else do nothing
            else
            {
                return;
            }
        }

        if( m_WaveNum == 4)
        {
            //populate enemy array
            //if play is active start spawning
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(WaveSpawner());
            }
            //else do nothing
            else
            {
                return;
            }
        }
            
        if( m_WaveNum == 5)
        {
            //populate enemy array
            //set MiniBoss to spawn
            //if play is active start spawning
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(WaveSpawner());
            }
            //else do nothing
            else
            {
                return;
            }
        }
            
        if( m_WaveNum == 6)
        {
            //populate enemy array
            //if play is active start spawning
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(WaveSpawner());
            }
            //else do nothing
            else
            {
                return;
            }
        }
            
        if( m_WaveNum == 7)
        {
            //populate enemy array
            //if play is active start spawning
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(WaveSpawner());
            }
            //else do nothing
            else
            {
                return;
            }
        }
            
        if (m_WaveNum == 8)
        {
            //populate enemy array
            //if play is active start spawning
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(WaveSpawner());
            }
            //else do nothing
            else
            {
                return;
            }
        }
            
        if(m_WaveNum == 9)
        {
            //populate enemy array
            //if play is active start spawning
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(WaveSpawner());
            }
            //else do nothing
            else
            {
                return;
            }
        }
            
        if(m_WaveNum == 10)
        {
            //populate enemy array
            //Set Boss to Spawn
            //if play is active start spawning
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                StartCoroutine(WaveSpawner());
            }
            //else do nothing
            else
            {
                return;
            }
        }
    }

    IEnumerator WaveSpawner()
    {
        yield return new WaitForSeconds(m_StartDelay);

        while (m_RequiredKills > 0)
        {
            m_WaveNum++;

            m_WaveText.text = m_WaveNum.ToString("F0");


            int numEnemies_ = 10;

            for (int i = 0; i < numEnemies_; ++i)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-m_SpawnArea.x, m_SpawnArea.x), m_SpawnArea.y, m_SpawnArea.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemiesInWave_[i], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(m_SpawnDelay);
            }
            yield return new WaitForSeconds(m_WaveDelay);

            if(GameObject.FindGameObjectWithTag("Player") == null)
            {
                m_Controller.gameOver_ = true;
            }
            if(m_Controller.gameOver_)
            {
                m_Controller.restart_ = true;
                m_Controller.GameOver();
                break;
            }
        }
    }
}
