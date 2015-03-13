using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Win : MonoBehaviour 
{
    public Button m_Continue;
    public Button m_Save_and_Quit;

    public PlayerData m_PData;

    public void Continue()
    {
        //save progress and let player continue playing
        m_PData.Save();
        //Application.LoadLevel();
    }

    public void SaveAndQuit()
    {
        //save player progress and quit application
        m_PData.Save();
        Application.Quit();
    }
}
