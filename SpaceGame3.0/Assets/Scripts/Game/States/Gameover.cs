using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gameover : MonoBehaviour 
{
    public GameData m_GData;

    public Button m_Restart;
    public Button m_Quit;

    public void Restart()
    {
        m_GData.Save();
        //Application.LoadLevel("Main");
    }

    public void Quit()
    {
        m_GData.Save();
    }
}
