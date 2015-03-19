using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gameover : MonoBehaviour 
{
    public PlayerData m_PData;

    public Button m_Restart;
    public Button m_Quit;

    public void Restart()
    {
        m_PData.Save();
        //Application.LoadLevel("Main");
    }

    public void Quit()
    {
        m_PData.Save();
    }
}
