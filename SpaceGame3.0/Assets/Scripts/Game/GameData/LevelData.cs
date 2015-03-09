using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelData : MonoBehaviour 
{
    public int m_SalavageCollected;
    public int m_EnemiesKilled;
    public int m_Socre;
    public int m_WavesCompleted;

    enum Enemies
    {
        LEVEL1 = 0,
        LEVEL2 = 1,
        LEVEL3 = 2,
        LEVEL4 = 3,
        LEVEL5 = 4
    }

    public enum Levels
    {
        LEVEL1 = 0,
        LEVEL2 = 1,
        LEVEL3 = 2,
        LEVEL4 = 3,
        LEVEL5 = 4
    }
    public Levels m_Level = Levels.LEVEL1;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SetLevelData()
    {
        switch(m_Level)
        {
            case Levels.LEVEL1:
                break;
            case Levels.LEVEL2:
                break;
            case Levels.LEVEL3:
                break;
            case Levels.LEVEL4:
                break;
            case Levels.LEVEL5:
                break;
        };
    }
}
