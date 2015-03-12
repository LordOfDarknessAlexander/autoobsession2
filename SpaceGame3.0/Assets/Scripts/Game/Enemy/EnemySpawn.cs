using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> m_Enemies;
    public List<GameObject> enemyPool_ = new List<GameObject>();
    public Text m_WaveText;
    public Text m_ReqKillText;
    public GameObject m_Type1Ememy;
    public GameObject m_Type2Ememy;
    public GameObject m_Type3Ememy;

    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;

    public int m_RequiredKills;
    public int m_WaveNum;
    public int m_NumEnemiesInPool;
    public int maxPoolSize_;

    public Vector3 m_SpawnArea;

    public void AISpawn()
    {
        if (m_WaveNum == 0)
        {
            m_WaveNum++;
            m_WaveText.text = m_WaveNum.ToString("F0");

            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);

            WaveSetup(10);
        }

        if (m_WaveNum == 1)
        {
            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            
            WaveSetup(10);
        }

        if (m_WaveNum == 2)
        {
            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(15);
        }

        if (m_WaveNum == 3)
        {
            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(20);
        }

        if (m_WaveNum == 4)
        {
            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(25);
        }

        if (m_WaveNum == 5)
        {
            //Set Boss to Spawn
            SpawnMiniBoss();
        }

        if (m_WaveNum == 6)
        {
            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(30);
        }

        if (m_WaveNum == 7)
        {
            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(35);
        }

        if (m_WaveNum == 8)
        {
            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(40);
        }

        if (m_WaveNum == 9)
        {
            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(45);
        }

        if (m_WaveNum == 10)
        {
            //Set Boss to Spawn
            SpawnBoss();
        }
    }

    public void SpawnBoss()
    {
        //m_RequiredKills = 45;
        m_ReqKillText.text = "BossShip";//m_RequiredKills.ToString("F0");

        //populate enemy array
        m_Enemies.Add(m_Type1Ememy);
        m_Enemies.Add(m_Type2Ememy);

        m_NumEnemiesInPool = 20;

        Debug.Log("Time to code that MiniBoss guys!");
        for (int e = 0; e < m_Enemies.Count; e++)
        {
            for (int i = 0; i < m_NumEnemiesInPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(m_Enemies[e]);
                obj.SetActive(false);
                enemyPool_.Add(obj);
            }
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            StartCoroutine(Camera.main.GetComponent<Waves>().BossSpawner());
        }
    }

    public void SpawnMiniBoss()
    {
        //m_RequiredKills = 45;
        m_ReqKillText.text = "MiniBossShip";//m_RequiredKills.ToString("F0");

        //populate enemy array
        m_Enemies.Add(m_Type1Ememy);
        m_Enemies.Add(m_Type2Ememy);


        m_NumEnemiesInPool = 15;



        //Debug.Log("Time to code that Boss guys!");
        for (int e = 0; e < m_Enemies.Count; e++)
        {
            for (int i = 0; i < m_NumEnemiesInPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(m_Enemies[e]);
                obj.SetActive(false);
                enemyPool_.Add(obj);
            }
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            StartCoroutine(Camera.main.GetComponent<Waves>().BossSpawner());
        }
    }

    public void WaveSetup(int kills)
    {
        Camera.main.GetComponent<GameController>().SoftSave();

        m_RequiredKills = kills;
        m_ReqKillText.text = m_RequiredKills.ToString("F0");

        m_NumEnemiesInPool = 10;

        for (int e = 0; e < m_Enemies.Count; e++)
        {
            for (int i = 0; i < m_NumEnemiesInPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(m_Enemies[e]);
                obj.SetActive(false);
                enemyPool_.Add(obj);
            }
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            StartCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());
        }
    }

    public void PopulateEnemyArray()
    {
        
    }
}
