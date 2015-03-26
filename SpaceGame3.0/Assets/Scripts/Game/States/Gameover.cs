using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gameover : MonoBehaviour 
{
    public GameData m_GData;

    public Button m_Continue;
    public Button m_Quit;

    public void Continue()
    {
        m_GData.Save();
        Application.LoadLevel("StarMap");
    }

    public void Quit()
    {
        m_GData.Save();
        Application.Quit();
    }
}
