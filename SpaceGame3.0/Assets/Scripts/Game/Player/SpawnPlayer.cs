using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPlayer : MonoBehaviour 
{
    public GameController m_Control;
    public GameObject m_Player;

    void Start()
    {
        m_Player = Camera.main.GetComponent<GameController>().m_Player;
    }

    public void Spawn()
    {

        if (Camera.main.GetComponent<GameController>().m_Lives > 0)
        {
            Camera.main.GetComponent<GameController>().m_ControlText.text = "";

            Camera.main.GetComponent<GameController>().m_Lives--;


            for(int i = 0; i < m_Control.playerPool.Count; i++)
            {
                Vector3 playerSpawn_ = new Vector3(0.0f, -5.0f, 0.0f);
                Quaternion spawnPlayerRotation = Quaternion.identity;

                m_Control.m_Player.GetComponent<PlayerShip>().ChangeSpirte();
                m_Control.m_Player.SetActive(true);
                m_Control.m_Player.transform.position = playerSpawn_;
                m_Control.m_Player.transform.rotation = spawnPlayerRotation;

            }
        }
        else if (Camera.main.GetComponent<GameController>().m_Lives == 0)
        {
            m_Control.m_GameOver = true;
            m_Control.GameOver();
        } 
    }
}
