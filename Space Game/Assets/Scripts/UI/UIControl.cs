using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public GameObject m_Player; //The player game object
    public Slider m_PlayerHealth; //Slider for the player's current health
    public Text m_LivesText; //Text element for the current number of lives the player has
    public Text m_ScoreText; //Text element for the player's current score

    private int maxPlayerHealth_; //Player's max health
    private int minHealth_ = 0; //Minimum health the player or enemy can ever have, obviously it's 0

    void Start()
    {
        maxPlayerHealth_ = m_Player.GetComponent<PlayerController>().m_Ship.m_HP;
        m_PlayerHealth.maxValue = maxPlayerHealth_;
        m_PlayerHealth.minValue = minHealth_;
    }

    void Update()
    {
        m_PlayerHealth.value = m_Player.GetComponent<PlayerController>().m_Ship.m_HP;
        m_PlayerHealth.minValue = minHealth_;
        m_LivesText.text = m_Player.GetComponent<PlayerController>().m_Lives.ToString();
        m_ScoreText.text = m_Player.GetComponent<PlayerController>().m_Score.ToString();
    }

   
}
