using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BossUIContol : MonoBehaviour 
{
    public GameObject m_BossObj; //The Boss game object
    public BossUIContol m_BossUI;
    public Slider m_BossHealth; //Slider for the Bosses current health
    public Slider m_BossShield;//Slider for the Bosses current shields

    private int maxBossHealth_; //Bosses max health
    private int minHealth_ = 0; //Minimum health the player or enemy can ever have, obviously it's 0

    private int currHealth_;
    private int currLives_;
    private int currScore_;
    private int currSalvage_;

    void Awake()
    {
        m_BossObj = Camera.main.GetComponent<EnemySpawn>().m_BossObj;

        maxBossHealth_ = m_BossObj.GetComponent<BossController>().m_Ship.m_SData.m_HP;
        m_BossHealth.maxValue = maxBossHealth_;
        m_BossHealth.minValue = minHealth_;
    }

    void Update()
    {
        if (m_BossObj != null)
        {
            currHealth_ = m_BossObj.GetComponent<ShipData>().m_HP;
            currLives_ = Camera.main.GetComponent<GameController>().m_Lives;
            currScore_ = Camera.main.GetComponent<GameController>().m_Score;
            currSalvage_ = Camera.main.GetComponent<GameController>().m_Salvage;

            m_BossHealth.value = m_BossObj.GetComponent<ShipData>().m_HP;
            m_BossShield.value = m_BossObj.GetComponent<ShipData>().m_CurrShield;
        }
    }
}
