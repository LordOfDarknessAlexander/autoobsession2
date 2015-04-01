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
    public List<GameObject> bossPool_ = new List<GameObject>();

    public CanvasGroup m_KillsPanel;
    public Canvas m_BossStatCanvas;

    public Text m_WaveText;
    public Text m_ReqKillText;
    public Text m_Control;

    public GameObject m_LightEmemy;
    public GameObject m_MediumEmemy;
    public GameObject m_HeavyEmemy;
    public GameObject m_MiniBoss;
    public GameObject m_Boss;
    public GameObject m_BossObj;

    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;

    public int m_RequiredKills;
    public int m_WaveNum;
    public int m_NumEnemiesInPool;
    public int maxPoolSize_;

    public GameObject m_Player;

    public void SetShipPrefab()
    {
        m_LightEmemy = m_LightEnemyPrefabs[m_GData.m_Level - 1];
        m_MediumEmemy = m_MediumEnemyPrefabs[m_GData.m_Level - 1];
        m_HeavyEmemy = m_HeavyEnemyPrefabs[m_GData.m_Level - 1];
        m_MiniBoss = m_MiniBossPrefabs[m_GData.m_Level - 1];
        m_Boss = m_BossPrefabs[m_GData.m_Level - 1];
    }
    public void Update()
    {
        m_Player = Camera.main.GetComponent<SpawnPlayer>().m_Player;

        if(Camera.main.GetComponent<GameController>().m_Play)
        {
            if (m_Player == null)
            {
                StopAllCoroutines();
                Camera.main.GetComponent<GameController>().Respawn();
            }

            if (m_RequiredKills == 0)
            {
                m_WaveNum++;
                m_WaveText.text = Camera.main.GetComponent<EnemySpawn>().m_WaveNum.ToString("F0");
                AISpawn();
            }

            if (Camera.main.GetComponent<GameController>().m_GameOver)
            {
                Camera.main.GetComponent<GameController>().m_Restart = true;
                Camera.main.GetComponent<GameController>().GameOver();
            }
        }
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
        }

        if (m_WaveNum == 1)
        {
            Camera.main.GetComponent<GameController>().SoftSave(m_Player);
            StopCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);

            WaveSetup(10);
        }

        if (m_WaveNum == 2)
        {
            Camera.main.GetComponent<GameController>().SoftSave(m_Player);

            StopCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());

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
            Camera.main.GetComponent<GameController>().SoftSave(m_Player);
            StopCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());

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
            Camera.main.GetComponent<GameController>().SoftSave(m_Player);
            StopCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());

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
            Camera.main.GetComponent<GameController>().SoftSave(m_Player);
            StopCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());

            //Set Boss to Spawn
            BossSetUp(m_MiniBoss, 15);
        }

        if (m_WaveNum == 6)
        {
            m_GData.Save();
            Camera.main.GetComponent<GameController>().SoftSave(m_Player);
            StopCoroutine(Camera.main.GetComponent<Waves>().BossSpawner());

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
            Camera.main.GetComponent<GameController>().SoftSave(m_Player);
            StopCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());

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
            Camera.main.GetComponent<GameController>().SoftSave(m_Player);
            StopCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());

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
            Camera.main.GetComponent<GameController>().SoftSave(m_Player);
            StopCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());

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
            Camera.main.GetComponent<GameController>().SoftSave(m_Player);
            StopCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());

            //Set Boss to Spawn
            BossSetUp(m_Boss, 20);
        }
    }

    public void BossSetUp(GameObject boss, int numEnemies)
    {

        m_BossObj = boss;

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

        GameObject bossObj = (GameObject)Instantiate(m_BossObj);
        m_BossObj.SetActive(false);
        bossPool_.Add(bossObj);

        Vector3 bossSpawn = new Vector3(0.0f, 8.0f, 0.0f);
        Quaternion spawnBossRotation = Quaternion.identity;

        m_BossObj.GetComponent<EnemyShip>().m_ShieldData.SetShield(m_BossObj);

        m_BossObj.SetActive(true);
        m_BossObj.transform.position = bossSpawn;
        m_BossObj.transform.rotation = spawnBossRotation;

        m_NumEnemiesInPool = numEnemies;

        enemyPool_.Capacity = m_NumEnemiesInPool;

        for (int e = 0; e < m_Enemies.Count; e++)
        {
            for (int i = 0; i < m_NumEnemiesInPool; i++)
            {
                //if(enemyPool_.Count > enemyPool_.Capacity)
                //{
                    GameObject obj = (GameObject)Instantiate(m_Enemies[e]);
                    obj.SetActive(false);
                    enemyPool_.Add(obj);
               //}
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

        m_NumEnemiesInPool = kills;

        enemyPool_.Capacity = m_NumEnemiesInPool;

        for (int i = 0; i < m_NumEnemiesInPool; i++)
        {
            int randEnemy = Random.Range(0, m_Enemies.Count);
            //for (int e = 0; e < m_Enemies.Count; e++)
            //{
                //if (enemyPool_.Count < enemyPool_.Capacity)
                //{
                    GameObject obj = (GameObject)Instantiate(m_Enemies[randEnemy]);
                    obj.SetActive(false);
                    enemyPool_.Add(obj);
                //}
            //}
        }
        StartCoroutine(Camera.main.GetComponent<Waves>().WaveSpawner());
    }

    public void DestroyAll()
    {
        for(int i = 0; i < enemyPool_.Count; ++i)
        {
            Destroy(enemyPool_[i]);

            enemyPool_.RemoveAt(i);
        }
    }
}
