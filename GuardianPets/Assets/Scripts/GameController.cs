using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public bool m_FirstTimePlayer = false; //Bool to determine whether or not we need to run the initial play segment
    public int m_Points; //Player's current points
    public int m_Shields; //Player's current shields
    public List<GameObject> m_Pets = new List<GameObject>(); //List of possible pets -- this needs to stay here in case they decide to buy more pets

    private string currPetName_; //Name of the current pet, used to find the right pet in the list
    private int maxPetsAllowed_ = 6;
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
        PlayerPrefs.GetInt("Points", m_Points);
        PlayerPrefs.GetInt("Shields", m_Shields);

        //currPetName_ = Camera.main.GetComponent<UIController>().m_SelectedPet;
        for (int i = 0; i < m_Pets.Count; ++i)
        {
            if (m_Pets[i].name == currPetName_)
            {
               pet_ = (GameObject)Instantiate(m_Pets[i]);
            }
        }
    }
}
