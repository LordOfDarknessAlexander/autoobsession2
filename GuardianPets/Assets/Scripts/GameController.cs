using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public bool m_FirstTimePlayer = false; //Bool to determine whether or not we need to run the initial play segment
    public List<GameObject> m_Pets = new List<GameObject>(); //List of possible pets -- this needs to stay here in case they decide to buy more pets
    public PlayerData m_PlayerData; //The player data

    private string currPetName_; //Name of the current pet, used to find the right pet in the list
    private float saveTimer_; //Timer between autosaves
    private float maxSaveTime_; //Max time between autosaves
    private GameObject pet_;
    private List<string> storedPets_ = new List<string>();

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
        PlayerPrefs.GetString("CurrPet", currPetName_);
        

        if (currPetName_ == null)
        {
            m_FirstTimePlayer = true;
            m_PlayerData.m_Points = Constants.DEFAULT_START_POINTS;
            m_PlayerData.m_Shields = Constants.DEFAULT_START_SHIELDS;
        }
        else
        {
            SetUpGame();
            //Below is storage stuff for later
            /*for (int i = 0; i < maxPetsAllowed_; ++i)
            {
                PlayerPrefs.GetString("StoredPet" + i, storedPets_[i].Insert(i, "Hi"));
            }*/
        }
	}
	
	void Update ()
    {
        if (pet_ != null)
        {
            pet_.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
	}

    public void SetUpGame()
    {
        //Call all load functions
        m_PlayerData.Load();

        //currPetName_ = Camera.main.GetComponent<UIController>().m_SelectedPet;
        for (int i = 0; i < m_Pets.Count; ++i)
        {
            if (m_Pets[i].name == currPetName_)
            {
                pet_ = (GameObject)Instantiate(m_Pets[i]);
            }
        }
    }

    //When this Save function is called, all other save functions get called. No where else should save.
    public void Save()
    {
        PlayerPrefs.SetString("CurrPet", currPetName_);
        pet_.GetComponent<Pet>().Save();
        m_PlayerData.Save();
    }

    //When this Load function is called, all other load functions get called. No where else should load.
    public void Load()
    {

    }
}
