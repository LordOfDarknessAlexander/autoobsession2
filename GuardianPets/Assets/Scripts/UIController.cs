using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    public GameObject m_GameUI;
    public GameObject m_NewPlayerUI;
    public GameObject m_NicknamePanel; //Panel for nickname prompt
    public GameObject m_FearPanel; //Panel for the fear prompt
    public InputField m_NicknameIF; //Input field for the nickname prompt
    public InputField m_FearIF; //Input field for the fear prompt
    public PlayerData m_PlayerData; //Player data

    public Text m_NicknameText;
    public Text m_PointsText; //Player's current points - UI element
    public Text m_ShieldsText; //Player's current shields = UI element
    public string m_SelectedPet;

    private GameObject currPet_;
    
    private GameController gc_; //Game Controller script for easier access
    private bool isNewPlayer_;

	void Start () 
    {
        gc_ = Camera.main.GetComponent<GameController>();
        isNewPlayer_ = gc_.m_FirstTimePlayer;

        if (isNewPlayer_)
        {
            m_GameUI.SetActive(false);
            m_NewPlayerUI.SetActive(true);
        }
        else
        {
            RemoveUI();
        }
	}
	
	void Update ()
    {
        currPet_ = gc_.ActivePet;
        if (currPet_ != null)
        {
            m_NicknameText.text = currPet_.GetComponent<Pet>().m_Nickname;
            m_PointsText.text = m_PlayerData.m_Points.ToString();
            m_ShieldsText.text = m_PlayerData.m_Shields.ToString();
        }
	}

    void RemoveUI()
    {
        Destroy(m_NewPlayerUI);
    }

    //Button function -- If the player is new, this button will be used to select their first pet
    //                -- After the player has selected their pet, it will prompt to give them a nickname
    public void SelectPet(GameObject btn)
    {
        m_SelectedPet = btn.name;
        gc_.CurrentPet = m_SelectedPet;
        PlayerPrefs.SetString("CurrPet", m_SelectedPet);
        m_NicknamePanel.SetActive(true);
        gc_.SetUpGame();
        gc_.Save();
    }

    //Button function -- When the player presses the "Done" button after typing in a nickname, this function fires
    //                -- The function will set the pet's nickname and activate the fear panel
    public void GiveNickname()
    {
        //gc_.Save();
        if(!string.IsNullOrEmpty(m_NicknameIF.text) && currPet_ != null)
        {
            currPet_.GetComponent<Pet>().m_Nickname = m_NicknameIF.text;
        }
        else if (string.IsNullOrEmpty(m_NicknameIF.text))
        {
            currPet_.GetComponent<Pet>().m_Nickname = currPet_.GetComponent<Pet>().m_PetName;
        }

        m_NicknamePanel.SetActive(false);
        m_FearPanel.SetActive(true);
    }

    //Button function -- When the player presses the "Done" button after typing in a fear, this function fires
    //                -- The function will remove the new player UI from the game, turn on the Game UI and start setting up the game itself
    public void AssignFear()
    {
        if(!string.IsNullOrEmpty(m_FearIF.text) && currPet_ != null)
        {
            currPet_.GetComponent<Pet>().m_FearOne = m_FearIF.text;
            gc_.Save();
            Destroy(m_NewPlayerUI);
            m_GameUI.SetActive(true);
        }
    }

    //Button function -- When the player presses the Shield, it will fire this function
    //                -- This function will give a visual display of the Upgrades available to them
    public void Upgrades()
    {

    }
}