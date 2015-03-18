using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> m_Enemies;
    public List<GameObject> enemyPool_ = new List<GameObject>();

    public CanvasGroup m_KillsPanel;
    public CanvasGroup m_BossStatCanvas;

    public Text m_WaveText;
    public Text m_ReqKillText;
    public GameObject m_Type1Ememy;
    public GameObject m_Type2Ememy;
    public GameObject m_Type3Ememy;
    public GameObject m_MiniBoss;
    public GameObject m_Boss;

    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;

    public int m_RequiredKills;
    public int m_WaveNum;
    public int m_NumEnemiesInPool;
    public int maxPoolSize_;

    public void AISpawn()
    {
        if (m_WaveNum == 0)
        {
            m_WaveNum++;
            m_WaveText.text = m_WaveNum.ToString("F0");

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();

            WaveSetup(10);
        }

        if (m_WaveNum == 1)
        {

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();

            WaveSetup(10);
        }

        if (m_WaveNum == 2)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(15);
        }

        if (m_WaveNum == 3)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(20);
        }

        if (m_WaveNum == 4)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();
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
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(30);
        }

        if (m_WaveNum == 7)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(35);
        }

        if (m_WaveNum == 8)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();
            m_Enemies.Add(m_Type2Ememy);

            WaveSetup(40);
        }

        if (m_WaveNum == 9)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_Type1Ememy);
            m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();
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
        //Turn on the Boss UI
        m_BossStatCanvas.alpha = 1;

        //turn off kills required panel
        m_KillsPanel.alpha = 0;

        //clear enemy array
        m_Enemies.Clear();
        enemyPool_.Clear();

        //populate enemy array
        m_Enemies.Add(m_Type1Ememy);
        m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();
        m_Enemies.Add(m_Type2Ememy);

        m_Boss.GetComponent<BossShip>().ChangeSpirte();
        m_Boss.SetActive(true);

        m_NumEnemiesInPool = 20;

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
        //Turn on the Boss UI
        m_BossStatCanvas.alpha = 1;

        //turn off kills required panel
        m_KillsPanel.alpha = 0;

        //clear enemy array
        m_Enemies.Clear();
        enemyPool_.Clear();

        //populate enemy array
        m_Enemies.Add(m_Type1Ememy);
        m_Type1Ememy.GetComponent<EnemyShip>().ChangeShip();
        m_Enemies.Add(m_Type2Ememy);
        m_Type2Ememy.GetComponent<EnemyShip>().ChangeShip();

        m_MiniBoss.GetComponent<MiniBossShip>().ChangeSpirte();
        m_MiniBoss.SetActive(true);

        m_NumEnemiesInPool = 15;

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
}
