using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelData : MonoBehaviour 
{
    public int m_CurrLevel;

    public int SetLevelData(int level)
    {
        m_CurrLevel = level;

        return m_CurrLevel;
    }
}
