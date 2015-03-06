using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPlayer : MonoBehaviour 
{
    public GameController m_Control;
    public GameObject m_Player;

    public int m_PooledAmt = 3;
    List<GameObject> lives_ = new List<GameObject>();

    void Start()
    {
        
    }

    public void Spawn()
    {
        for (int i = 0; i < m_PooledAmt; i++)
        {
            GameObject obj = (GameObject)Instantiate(m_Player);
            obj.SetActive(false);
            lives_.Add(obj);
        }

        m_Player = lives_[0];

        m_Control.m_Lives = m_PooledAmt;

       //m_Player = lives_[0];

        if (m_Control.m_Lives > 0)
        {
            m_Control.m_LivesText.text = m_Control.m_Lives.ToString();

            Vector3 playerSpawn_ = new Vector3(0.0f, -5.0f, 0.0f);
            Quaternion spawnPlayerRotation = Quaternion.identity;

            m_Player.SetActive(true);
            m_Player.transform.position = playerSpawn_;
            m_Player.transform.rotation = spawnPlayerRotation;
            
        }
        else if (m_Control.m_Lives == 0)
        {
            m_Control.gameOver_ = true;
            m_Control.GameOver();
        } 
    }

    public void Respawn()
    {
        Spawn();
    }
        
}
