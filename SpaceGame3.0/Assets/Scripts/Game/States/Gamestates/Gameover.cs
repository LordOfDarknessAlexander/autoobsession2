using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gameover : MonoBehaviour 
{
    public GameData m_GData;

    public Text m_TotalEnemiesKilled;
    public Text m_FinalScore;

    public Button m_Continue;
    public Button m_Quit;

    public void Awake()
    {
        m_TotalEnemiesKilled.text = Camera.main.GetComponent<GameController>().m_Kills.ToString();
        m_FinalScore.text = Camera.main.GetComponent<GameController>().m_Score.ToString();
    }

    public void Continue()
    {
        m_GData.Save();
        Application.LoadLevel("StarMap");
    }

    public void Quit()
    {
        m_GData.Save();
        Application.LoadLevel("Start");
    }
}
