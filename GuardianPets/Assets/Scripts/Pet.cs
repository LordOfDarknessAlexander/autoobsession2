﻿using UnityEngine;
using System.Collections;

public class Pet : MonoBehaviour
{
    public string m_PetName; //The name of the pet
    public string m_Nickname; //Nickname of the pet -- created by the player
    public int m_Hunger; //The pet's hunger level -- 100 is max, 0 is min. Max is starving, min is full. Max = bad, Min = good.
    public int m_Cleanliness; //The pet's cleanliness level -- 100 is max, 0 is min. Max is filthy, min is spotless. Max = bad, Min = good.
    public int m_Bored; //The pet's bored level -- 100 is max, 0 is min. Max is extremely bored, min is entertained. Max = bad, Min = good.

	void Start ()
    {
        PlayerPrefs.GetString("Nickname", m_Nickname);
        PlayerPrefs.GetInt(m_PetName + "Hunger", m_Hunger);
        PlayerPrefs.GetInt(m_PetName + "Cleanliness", m_Cleanliness);
        PlayerPrefs.GetInt(m_PetName + "Boredom", m_Bored);
	}
	
	void Update () 
    {
	    
	}
}
