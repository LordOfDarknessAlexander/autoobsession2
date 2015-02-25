using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{
	void Start ()
    {
        Screen.orientation = ScreenOrientation.Landscape;
	}
	
	void Update () 
    {
	
	}

    //Button function -- When the player presses the "Play" button this function will fire
    public void Play()
    {
        Application.LoadLevel("Game");
    }

    //Button function -- When the player presses the "Options" button this function will fire
    public void Options()
    {

    }
}