using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public List<Pet> m_Pets = new List<Pet>();
    public int m_Points;
    public int m_Shields;

    private List<string> petString_ = new List<string>();

	void Start ()
    {
        Load();
	}
	
	void Update ()
    {
	
	}

    public void Save()
    {
        PlayerPrefs.SetInt("Points", m_Points);
        PlayerPrefs.SetInt("Shields", m_Shields);
    }

    public void Load()
    {
        string tempStr = "";

        PlayerPrefs.GetInt("Points", m_Points);
        PlayerPrefs.GetInt("Shields", m_Shields);
        PlayerPrefs.GetString("PetOne", tempStr);
    }
}
