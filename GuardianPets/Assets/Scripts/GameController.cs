using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour
{
    public bool m_FirstTimePlayer = false; //Bool to determine whether or not we need to run the initial play segment
    public List<GameObject> m_PetChoices = new List<GameObject>(); //List of possible pets -- this needs to stay here in case they decide to buy more pets
    public PlayerData m_PlayerData; //The player data

    private string currPetName_; //Name of the current pet, used to find the right pet in the list
    private float saveTimer_; //Timer between autosaves
    private float maxSaveTime_; //Max time between autosaves
    private GameObject pet_;

    public string CurrentPet
    {
        set { currPetName_ = value; }
    }

    public GameObject ActivePet
    {
        get { return pet_; }
    }

	void Awake ()
    {
        Load();
	}
	
	void Update ()
    {
        if (pet_ != null)
        {
            pet_.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 5.0f));
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Save();
            if (Application.platform == RuntimePlatform.Android)
            {
                Application.Quit();
            }
            else
            {
                Application.Quit();
            }
        }
	}

    public void SetUpGame()
    {
        //currPetName_ = Camera.main.GetComponent<UIController>().m_SelectedPet;
        for (int i = 0; i < m_PetChoices.Count; ++i)
        {
            if (m_PetChoices[i].name == currPetName_)
            {
                pet_ = (GameObject)Instantiate(m_PetChoices[i]);
                pet_.name = m_PetChoices[i].name;
            }
        }
    }

    //When this Save function is called, all other save functions get called. No where else should save.
    public void Save()
    {
        if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "gpSaveData.dat"))
        {
            Debug.Log("Creating file");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "gpSaveData.dat");
            SaveData sData = new SaveData();

            //Insert save data here
            for (int i = 0; i < m_PlayerData.m_Pets.Count; ++i)
            {
                sData.m_Pets.Add(m_PlayerData.m_Pets[i].GetComponent<Pet>().m_PetName);
            }
            sData.m_Energy = m_PlayerData.m_Energy;
            sData.m_Shields = m_PlayerData.m_Shields;
            sData.m_CloseDate = DateTime.Now;
            sData.m_CurrPet = pet_.name;
            sData.m_CurrPetNickname = "Temp";

            bf.Serialize(file, sData);
            file.Close();
        }
        else
        {
            Debug.Log("Saving to " + Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "gpSaveData.dat", FileMode.Open);
            SaveData sData = new SaveData();

            //Insert save data here
            for (int i = 0; i < m_PlayerData.m_Pets.Count; ++i)
            {
                sData.m_Pets.Add(m_PlayerData.m_Pets[i].GetComponent<Pet>().m_PetName);
            }
            sData.m_Energy = m_PlayerData.m_Energy;
            sData.m_Shields = m_PlayerData.m_Shields;
            sData.m_CloseDate = DateTime.Now;
            sData.m_CurrPet = pet_.name;
            sData.m_CurrPetNickname = "Temp";

            bf.Serialize(file, sData);
            file.Close();
        }
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "gpSaveData.dat"))
        {
            Debug.Log("Loading from " + Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "gpSaveData.dat", FileMode.Open);
            SaveData sData = (SaveData)bf.Deserialize(file);

            //Insert load data here
            for (int i = 0; i < m_PetChoices.Count; ++i)
            {
                for (int j = 0; j < sData.m_Pets.Count; ++j)
                {
                    if(sData.m_Pets[j] == m_PetChoices[i].name)
                    {
                        if(m_PetChoices[i].name == sData.m_CurrPet)
                        {
                            pet_ = (GameObject)Instantiate(m_PetChoices[i]);
                            pet_.name = m_PetChoices[i].name;
                            m_PlayerData.m_Pets.Add(pet_);
                        }
                        else
                        {
                            m_PlayerData.m_Pets.Add(m_PetChoices[i]);
                        }
                    }
                }
            }
            m_PlayerData.m_Shields = sData.m_Shields;
            DateTime now = DateTime.Now;
            TimeSpan ts = now - Convert.ToDateTime(sData.m_CloseDate);
            float minutesElapsed = (float)ts.TotalMinutes / 5;
            float energyToAdd;
            if(minutesElapsed >= 1)
            {
                energyToAdd = minutesElapsed;
            }
            else
            {
                energyToAdd = 0;
            }

            m_PlayerData.m_Energy = sData.m_Energy + (int)energyToAdd;
            if(m_PlayerData.m_Energy > Constants.DEFAULT_MAX_ENERGY)
            {
                m_PlayerData.m_Energy = Constants.DEFAULT_MAX_ENERGY;
            }

            SetUpGame();
            file.Close();
            m_FirstTimePlayer = false;
        }
        else
        {
            Debug.Log("Failed to load, file doesn't exist");
            m_FirstTimePlayer = true;
            m_PlayerData.m_Energy = Constants.DEFAULT_START_ENERGY;
            m_PlayerData.m_Shields = Constants.DEFAULT_START_SHIELDS;
        }
    }
}

[Serializable]
class SaveData
{
    public List<string> m_Pets = new List<string>(); //List of pets the player owns
    public string m_CurrPet; //Player's currently active pet
    public string m_CurrPetNickname; //Player's currently active pet's nickname
    public int m_Shields; //Player's current shields
    public int m_Energy; //Player's points at the time of the save
    public DateTime m_CloseDate; //Date the player stopped playing
}
