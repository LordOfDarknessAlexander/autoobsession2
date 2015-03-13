using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

[Serializable]
public class GameData : MonoBehaviour 
{
    public static GameData m_GData;

    //Game Data
    public int m_CurrLevel;
    public float m_MasterVol;
    public float m_MusicVol;
    public float m_SFXVol;
    
	// Use this for initialization
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
        m_CurrLevel = 0;
	}
}