using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public GameData m_GData;
    public PlayerData m_PData;

    public GameObject m_GameControl;
    public GameObject m_Player; //The player game object
    public Slider m_PlayerHealth; //Slider for the player's current health
    public Slider m_PlayerShield;//Slider that is activated to show player shiled health, turn off if hasShield is false;
    public Text m_LivesVal; //Text element for the current number of lives the player has
    public Text m_ScoreVal; //Text element for the player's current score
    public Text m_SalvageVal;

    private int maxPlayerHealth_; //Player's max health
    private int minHealth_ = 0; //Minimum health the player or enemy can ever have, obviously it's 0
    private int maxPlayerShield_;
    private int minShield_ = 0;
   
    private int currHealth_;
    private int currShield_;
    private int currLives_;
    private int currScore_;
    private int currSalvage_;

    //Stats UI code
    public int m_EnemiesKilledLifetime;
    public int m_WavesCompleted;

    void Start()
    {
        m_Player = Camera.main.GetComponent<SpawnPlayer>().m_Player;

        m_EnemiesKilledLifetime = m_PData.m_EnemiesKilledLifetime;
        m_WavesCompleted = m_PData.m_WavesCompleted;


        maxPlayerShield_ = m_Player.GetComponent<PlayerController>().m_PlayerShip.m_SData.m_Shield;
        m_PlayerShield.maxValue = maxPlayerShield_;
        m_PlayerShield.minValue = minShield_;

        m_PlayerShield.image.enabled = false;

        maxPlayerHealth_ = m_Player.GetComponent<PlayerController>().m_PlayerShip.m_SData.m_HP;
        m_PlayerHealth.maxValue = maxPlayerHealth_;
        m_PlayerHealth.minValue = minHealth_;
    }

    void Update()
    {
        if(m_Player != null)
        {
            currHealth_ = m_Player.GetComponent<ShipData>().m_HP;
            currShield_ = m_Player.GetComponent<ShipData>().m_Shield;
            currLives_ = m_GameControl.GetComponent<GameController>().m_Lives;
            currScore_ = m_GameControl.GetComponent<GameController>().m_Score;
            currSalvage_ = m_GameControl.GetComponent<GameController>().m_Salvage;

            if(m_Player.GetComponent<ShipData>().m_HasShield)
            {
                if (m_Player.GetComponent<ShipData>().m_Shield > minShield_)
                {
                    m_PlayerShield.image.enabled = true;
                    m_PlayerShield.value = m_Player.GetComponent<ShipData>().m_Shield;
                }
                else
                {
                    m_PlayerShield.image.enabled = false;
                }
            }
        
            m_PlayerHealth.value = m_Player.GetComponent<ShipData>().m_HP;
            m_LivesVal.text = currLives_.ToString();
            m_ScoreVal.text = currScore_.ToString();
            m_SalvageVal.text = currSalvage_.ToString();
        }
    }
}
