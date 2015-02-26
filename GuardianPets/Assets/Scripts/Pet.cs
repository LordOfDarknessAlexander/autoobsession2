using UnityEngine;
using System.Collections;

public class Pet : MonoBehaviour
{
    public string m_PetName; //The name of the pet
    public string m_Nickname; //Nickname of the pet -- created by the player
    public int m_Hunger; //The pet's hunger level -- 100 is max, 0 is min. Max is starving, min is full. Max = bad, Min = good.
    public int m_Cleanliness; //The pet's cleanliness level -- 100 is max, 0 is min. Max is filthy, min is spotless. Max = bad, Min = good.
    public int m_Bored; //The pet's bored level -- 100 is max, 0 is min. Max is extremely bored, min is entertained. Max = bad, Min = good.
    public string m_FearOne; //The fear the player chose when they picked the pet
    public string m_FearTwo; //This fear is only used if the player pays for a second fear slot

	void Start ()
    {
        
	}
	
	void Update () 
    {
	    
	}

    public void Save()
    {
        PlayerPrefs.SetString(m_PetName + "Nickname", m_Nickname);
        PlayerPrefs.SetInt(m_PetName + "Hunger", m_Hunger);
        PlayerPrefs.SetInt(m_PetName + "Cleanliness", m_Cleanliness);
        PlayerPrefs.SetInt(m_PetName + "Boredom", m_Bored);
        PlayerPrefs.SetString(m_PetName + "FearOne", m_FearOne);
        PlayerPrefs.SetString(m_PetName + "FearTwo", m_FearTwo);
    }

    public void Load()
    {
        PlayerPrefs.GetString(m_PetName + "Nickname", m_Nickname);
        PlayerPrefs.GetInt(m_PetName + "Hunger", m_Hunger);
        PlayerPrefs.GetInt(m_PetName + "Cleanliness", m_Cleanliness);
        PlayerPrefs.GetInt(m_PetName + "Boredom", m_Bored);
        PlayerPrefs.GetString(m_PetName + "FearOne", m_FearOne);
        PlayerPrefs.GetString(m_PetName + "FearTwo", m_FearTwo);
    }

    //Button function -- When the player presses the feed button on the UI it will call this function
    //                -- This function will decrease the hunger level of the pet, remove the appropriate points from the player, and award them shields
    public void Feed()
    {
        m_Hunger -= Constants.FEED_AMOUNT;
        if(m_Hunger >= Constants.MAX_PET_STAT)
        {
            m_Hunger = Constants.MAX_PET_STAT;
        }

        
    }

    //Button function -- When the player presses the play button on the UI it will call this function
    //                -- This function will decrease the boredom level of the pet, remove the appropriate points from the player, and award them shields
    public void Play()
    {

    }

    //Button function -- When the player presses the clean button on the UI it will call this function
    //                -- This function will decrease the cleanliness level of the pet, remove the appropriate points from the player, and award them shields
    public void Clean()
    {

    }
}
