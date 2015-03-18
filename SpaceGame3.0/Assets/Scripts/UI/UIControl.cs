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
    public Text m_LivesVal; //Text element for the current number of lives the player has
    public Text m_ScoreVal; //Text element for the player's current score
    public Text m_SalvageVal;

    private int maxPlayerHealth_; //Player's max health
    private int minHealth_ = 0; //Minimum health the player or enemy can ever have, obviously it's 0
   
    private int currHealth_;
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

        maxPlayerHealth_ = m_Player.GetComponent<PlayerController>().m_PlayerShip.m_Data.m_HP;
        m_PlayerHealth.maxValue = maxPlayerHealth_;
        m_PlayerHealth.minValue = minHealth_;
    }

    void Update()
    {
        currHealth_ = m_Player.GetComponent<ShipData>().m_HP;
        currLives_ = m_GameControl.GetComponent<GameController>().m_Lives;
        currScore_ = m_GameControl.GetComponent<GameController>().m_Score;
        currSalvage_ = m_GameControl.GetComponent<GameController>().m_Salvage;

        if(m_Player != null)
        {
            m_PlayerHealth.value = m_Player.GetComponent<ShipData>().m_HP;
            //Debug.Log(currHealth_);
            m_LivesVal.text = currLives_.ToString();//m_GameControl.GetComponent<GameController>().m_Lives.ToString();
            //Debug.Log(currLives_);
            m_ScoreVal.text = currScore_.ToString();//m_GameControl.GetComponent<GameController>().m_Score.ToString();
            //Debug.Log(currScore_);
            m_SalvageVal.text = currSalvage_.ToString();
        }
    }
}
