using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Waves : MonoBehaviour 
{   
    public GameObject[] m_Enemies;
    public Text m_WaveText;

    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;

    public int m_WaveNum;

    private float numEnemies_;
    private GameObject[] enemiesInWave_;

    public Vector3 m_SpawnArea;

    public GameController m_Controller;

    public void AISpawn()
    {
            //if wave == 1
                //populate enemy array
                //check for player
                //if player active start spawning
                //else do nothing
            
            //if wave == 2
                //populate enemy array
                //check for player
                //if player active start spawning
                //else do nothing

            //if wave == 3
                //populate enemy array
                //check for player
                //if player active start spawning
                //else do nothing

            //if wave == 4
                //populate enemy array
                //check for player
                //if player active start spawning
                //else do nothing
            
            //if wave == 5
                //populate enemy array
                //check for player
                //if player active start spawning
                //else do nothing
            
            //if wave == 6
                //populate enemy array
                //check for player
                //if player active start spawning
                //else do nothing
            
            //if wave == 7
                //populate enemy array
                //check for player
                //if player active start spawning
                //else do nothing
            
            //if wave == 8
                //populate enemy array
                //check for player
                //if player active start spawning
                //else do nothing
            
            //if wave == 9
                //populate enemy array
                //check for player
                //if player active start spawning
                //else do nothing
            
            //if wave == 10
                //populate enemy array
                //check for player
                //if player active start spawning
                //else do nothing
    }

    IEnumerator WaveSpawner()
    {
        yield return new WaitForSeconds(m_StartDelay);

        while (m_Controller.gameOver_)
        {
            m_WaveNum++;

            m_WaveText.text = m_WaveNum.ToString("F0");

            numEnemies_ = m_Enemies.Length;

            for (int i = 0; i < numEnemies_; ++i)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-m_SpawnArea.x, m_SpawnArea.x), m_SpawnArea.y, m_SpawnArea.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(m_Enemies[i], spawnPosition, spawnRotation);
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
