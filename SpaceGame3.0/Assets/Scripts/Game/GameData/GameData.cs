using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

[System.Serializable]
public class GameData : MonoBehaviour 
{
    public static GameData m_GData;

    //Game Data
    public int m_CurrLevel;
    public float m_MasterVol;
    public float m_MusicVol;
    public float m_SFXVol;

    //Enemy Data
    public bool m_HasShield;

    public int m_Level;
    public int m_EnemyTier;
    public int m_EnemyHP;
    public int m_EnemyShield;

    public int m_EnemyEngineLevel;
    public int m_EnemyDamageLevel;
    public int m_EnemyHealthLevel;
    public int m_EnemyShieldLevel;
    public int m_SalvageVal;
    
	void Start () 
    {
	    if(m_GData == null)
        {
            DontDestroyOnLoad(gameObject);
            m_GData = this;
        }
        else if(m_GData != null)
        {
            Destroy(gameObject);
        }

        //Initalizing Default Game Values
        m_MasterVol = 100;
        m_MusicVol = 100;
        m_SFXVol = 100;

        //Initalize Enemy Data
        m_HasShield = false;

        m_Level = m_CurrLevel;
        m_EnemyTier = 1;
        m_EnemyHP = 5;
        m_EnemyShield = 5;

        m_EnemyEngineLevel = 1 * m_EnemyTier;
        m_EnemyDamageLevel = 1 * m_EnemyTier;
        m_EnemyHealthLevel = 1 * m_EnemyTier;
        m_EnemyShieldLevel = 1 * m_EnemyTier;
        m_SalvageVal = 100 * (m_Level * m_EnemyTier);
	}
}