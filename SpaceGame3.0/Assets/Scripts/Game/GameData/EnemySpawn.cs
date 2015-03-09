using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] m_Enemies;
    public Text m_WaveText;
    public Text m_ReqKillText;

    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;

    public int m_RequiredKills;
    public int m_WaveNum;

    public List<GameObject> enemyPool_ = new List<GameObject>();

    public Vector3 m_SpawnArea;


    public void AISpawn()
    {
        if (m_WaveNum == 0)
        {
            m_WaveNum++;
            m_WaveText.text = m_WaveNum.ToString("F0");

            WaveSetup(10);
        }

        if (m_WaveNum == 1)
        {
            //populate enemy array
            WaveSetup(10);
        }

        if (m_WaveNum == 2)
        {
            //populate enemy array
            WaveSetup(15);
        }

        if (m_WaveNum == 3)
        {
            //populate enemy array
            WaveSetup(20);
        }

        if (m_WaveNum == 4)
        {
            //populate enemy array
            WaveSetup(25);
        }

        if (m_WaveNum == 5)
        {
            //Set Boss to Spawn
            SpawnBoss();
        }

        if (m_WaveNum == 6)
        {
            //populate enemy array
            WaveSetup(30);
        }

        if (m_WaveNum == 7)
        {
            //populate enemy array
            WaveSetup(35);
        }

        if (m_WaveNum == 8)
        {
            WaveSetup(40);
        }

        if (m_WaveNum == 9)
        {
            //populate enemy array
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
        m_RequiredKills = 45;
        m_ReqKillText.text = m_RequiredKills.ToString("F0");

        Debug.Log("Time to code that MiniBoss guys!");
        for (int e = 0; e < m_Enemies.Length; e++)
        {
            for (int i = 0; i < m_RequiredKills; i++)
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
        m_RequiredKills = 45;
        m_ReqKillText.text = m_RequiredKills.ToString("F0");

        Debug.Log("Time to code that Boss guys!");
        for (int e = 0; e < m_Enemies.Length; e++)
        {
            for (int i = 0; i < m_RequiredKills; i++)
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
        m_RequiredKills = kills;
        m_ReqKillText.text = m_RequiredKills.ToString("F0");

        for (int e = 0; e < m_Enemies.Length; e++)
        {
            for (int i = 0; i < m_RequiredKills; i++)
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
}
