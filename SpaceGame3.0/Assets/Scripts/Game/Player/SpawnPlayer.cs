using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPlayer : MonoBehaviour 
{
    public GameController m_Control;
    public GameObject m_Player;
    public UIControl m_UIControl;

    void Start()
    {
        
    }

    public void Spawn()
    {

        if (Camera.main.GetComponent<GameController>().m_Lives > 0)
        {
            //m_Control.m_Lives--;
            Camera.main.GetComponent<GameController>().m_Lives--;

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
}
