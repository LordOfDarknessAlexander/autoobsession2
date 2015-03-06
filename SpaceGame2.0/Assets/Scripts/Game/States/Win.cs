using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Win : MonoBehaviour 
{
    public Button m_Continue;
    public Button m_Save_and_Quit;

    public GameController m_GameController;

    public void Continue()
    {
        //save progress and let player continue playing
        m_GameController.Save();
        //Application.LoadLevel();
    }

    public void SaveAndQuit()
    {
        //save player progress and quit application
        m_GameController.Save();
        Application.Quit();
    }
}
