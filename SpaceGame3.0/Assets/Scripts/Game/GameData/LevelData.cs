using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelData : MonoBehaviour 
{
    public GameData m_GData;

    public int m_CurrLevel;

    public int m_EnemyTier;
    public int m_EnemyType;

    public void SetLevelData(int level)
    {
        m_GData.m_CurrLevel = level;
        m_GData.m_EnemyType = level;
    }

    public void LoadLevelData()
    {
        m_CurrLevel = m_GData.m_CurrLevel;
        m_EnemyType = m_GData.m_EnemyType;
    }
}
