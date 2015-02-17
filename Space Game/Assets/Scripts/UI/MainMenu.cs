using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
    public Button m_Start;
    public Button m_Quit;
    public Slider m_MasterVolControl;
    public Slider m_SFXVolControl;
    public Slider m_MusicVolControl;

    public void StartGame()
    {
        Application.LoadLevel("Main");
    }

    public void Quit()
    {
        Application.OpenURL("http://triosdevelopers.com/J.Corrigan/projects.html");
    }

    public void OptionsMenu()
    {

    }
}
