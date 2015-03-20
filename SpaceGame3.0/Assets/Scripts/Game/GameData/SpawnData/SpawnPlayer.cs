using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPlayer : MonoBehaviour 
{
    public GameData m_GData;
    public PlayerData m_PData;

    public List<GameObject> m_PlayerPrefab = new List<GameObject>();
    public List<GameObject> playerPool = new List<GameObject>();

    public GameObject m_Player;
    private GameObject playerObj_;


    public void SetStats(GameObject player)
    {
        //m_GData.Load();

        m_Player.GetComponent<PlayerShip>().m_DamageModifier = m_PData.m_DamageModifer;
        m_Player.GetComponent<PlayerController>().m_Salvage = m_PData.m_Salvage;
        m_Player.GetComponent<ShipData>().m_HP = m_PData.m_HP;
        m_Player.GetComponent<ShipData>().m_HasShield = m_PData.m_HasShield;
        m_Player.GetComponent<ShipData>().m_Shield = m_PData.m_Shield;
        m_Player.GetComponent<ShipData>().m_MaxCargoCapacity = (100 * (m_Player.GetComponent<ShipData>().SetCargoCapacity())) * (m_PData.m_EngineModifier);
        m_Player.GetComponent<ShipData>().m_Inventory = m_PData.m_Items;
    }

    public void Spawn()
    {

        if (Camera.main.GetComponent<GameController>().m_Lives > 0)
        {
            Camera.main.GetComponent<GameController>().m_ControlText.text = "";

            Camera.main.GetComponent<GameController>().m_Lives--;

            playerObj_ = m_PlayerPrefab[m_PData.m_ShipLevel - 1];
            GameObject obj = (GameObject)Instantiate(playerObj_);
            playerPool.Add(obj);

            m_Player = playerPool[0];
            SetStats(m_Player);

            for(int i = 0; i < playerPool.Count; i++)
            {
                Vector3 playerSpawn_ = new Vector3(0.0f, -5.0f, 0.0f);
                Quaternion spawnPlayerRotation = Quaternion.identity;

                m_Player.SetActive(true);
                m_Player.transform.position = playerSpawn_;
                m_Player.transform.rotation = spawnPlayerRotation;

            }
        }
        else if (Camera.main.GetComponent<GameController>().m_Lives == 0)
        {
            Camera.main.GetComponent<GameController>().m_GameOver = true;
            Camera.main.GetComponent<GameController>().GameOver();
        } 
    }
}
