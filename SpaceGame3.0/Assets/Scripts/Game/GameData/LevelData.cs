using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelData : MonoBehaviour 
{
    public int m_CurrLevel;

    public enum Levels
    {
        LEVEL1,
        LEVEL2,
        LEVEL3,
        LEVEL4,
        LEVEL5
    }
    public Levels m_Level = Levels.LEVEL1;


    public void SetLevelData(Ship ship)
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

    public void SetLevelData()
    {
        m_CurrLevel = (int)m_Level;
    }
}
