using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelData : MonoBehaviour 
{
    public int m_CurrLevel;

    public enum Levels
    {
        LEVEL1 = 1,
        LEVEL2 = 2,
        LEVEL3 = 3,
        LEVEL4 = 4,
        LEVEL5 =5
    }
    public Levels m_Level = Levels.LEVEL1;


    public void SetLevelData()
    {
 
        switch(m_Level)
        {
            case Levels.LEVEL1:
                m_CurrLevel = 1;
                break;
            case Levels.LEVEL2:
                m_CurrLevel = 2;
                break;
            case Levels.LEVEL3:
                m_CurrLevel = 3;
                break;
            case Levels.LEVEL4:
                m_CurrLevel = 4;
                break;
            case Levels.LEVEL5:
                m_CurrLevel = 5;
                break;
        };
    }
}
