using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarMapUI : MonoBehaviour
{
    public Button Level1;
    public Button Level2;
    public Button Level3;
    public Button Level4;
    public Button Level5;
    public Button SpaceStation;

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


    public void SetLevelData()
    {
        switch (m_Level)
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

    public void SetLevel()
    {
        Camera.main.GetComponent<LevelData>().m_CurrLevel = 0;
    }
}
