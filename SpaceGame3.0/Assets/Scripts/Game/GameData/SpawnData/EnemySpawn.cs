using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public GameData m_GData;

    public List<GameObject> m_Enemies = new List<GameObject>();
    public List<GameObject> m_CurrentEnemies = new List<GameObject>();
    public List<GameObject> m_LightEnemyPrefabs = new List<GameObject>();
    public List<GameObject> m_MediumEnemyPrefabs = new List<GameObject>();
    public List<GameObject> m_HeavyEnemyPrefabs = new List<GameObject>();
    public List<GameObject> m_MiniBossPrefabs = new List<GameObject>();
    public List<GameObject> m_BossPrefabs = new List<GameObject>();
    public List<GameObject> enemyPool_ = new List<GameObject>();

    public CanvasGroup m_KillsPanel;
    public Canvas m_BossStatCanvas;

    public Text m_WaveText;
    public Text m_ReqKillText;

    public GameObject m_LightEmemy;
    public GameObject m_MediumEmemy;
    public GameObject m_HeavyEmemy;
    public GameObject m_MiniBoss;
    public GameObject m_Boss;

    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;

    public int m_RequiredKills;
    public int m_WaveNum;
    public int m_NumEnemiesInPool;
    public int maxPoolSize_;

    public void SetShipPrefab()
    {
        m_LightEmemy = m_LightEnemyPrefabs[m_GData.m_Level - 1];
        m_MediumEmemy = m_MediumEnemyPrefabs[m_GData.m_Level - 1];
        m_HeavyEmemy = m_HeavyEnemyPrefabs[m_GData.m_Level - 1];
        m_MiniBoss = m_MiniBossPrefabs[m_GData.m_Level - 1];
        m_Boss = m_BossPrefabs[m_GData.m_Level - 1];
    }

    public void AISpawn()
    {
        if (m_WaveNum == 0)
        {
            m_WaveNum++;
            m_WaveText.text = m_WaveNum.ToString("F0");

            SetShipPrefab();

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);

            WaveSetup(10);
        }

        if (m_WaveNum == 1)
        {

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);

            WaveSetup(10);
        }

        if (m_WaveNum == 2)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);

            WaveSetup(15);
        }

        if (m_WaveNum == 3)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);

            WaveSetup(20);
        }

        if (m_WaveNum == 4)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);
            m_Enemies.Add(m_HeavyEmemy);

            WaveSetup(25);
        }

        if (m_WaveNum == 5)
        {
            //Set Boss to Spawn
            SpawnBoss(m_MiniBoss, 15);
        }

        if (m_WaveNum == 6)
        {

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);
            m_Enemies.Add(m_HeavyEmemy);

            WaveSetup(30);
        }

        if (m_WaveNum == 7)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);
            m_Enemies.Add(m_HeavyEmemy);

            WaveSetup(35);
        }

        if (m_WaveNum == 8)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);
            m_Enemies.Add(m_HeavyEmemy);

            WaveSetup(40);
        }

        if (m_WaveNum == 9)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);
            m_Enemies.Add(m_HeavyEmemy);

            WaveSetup(45);
        }

        if (m_WaveNum == 10)
        {
            //Set Boss to Spawn
            SpawnBoss(m_Boss, 20);
        }
    }

    public void SpawnBoss(GameObject boss, int numEnemies)
    {
        m_Boss = boss;

        //Turn on the Boss UI
        m_BossStatCanvas.enabled = true;

        //turn off kills required panel
        m_KillsPanel.alpha = 0;

        //clear enemy array
        m_Enemies.Clear();
        enemyPool_.Clear();

        //populate enemy array
        m_Enemies.Add(m_LightEmemy);
        m_Enemies.Add(m_MediumEmemy);

        //m_Boss.GetComponent<Ship>().ChangeShip();
        m_Boss.SetActive(true);

        m_NumEnemiesInPool = numEnemies;

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

   /* public void SpawnMiniBoss(GameObject miniBoss)
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
        m_Enemies.Add(m_Type2Ememy);

        m_Boss.GetComponent<MiniBossShip>().ChangeSpirte();
        m_Boss.SetActive(true);

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
    }*/

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
