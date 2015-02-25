using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    public GameObject m_GameUI;
    public GameObject m_NewPlayerUI;
    public GameObject m_NicknamePanel; //Panel for nickname prompt
    public InputField m_NicknameIF; //Input field for the nickname prompt
    public Text m_NicknameText;
    public Text m_PointsText; //Player's current points - UI element
    public Text m_ShieldsText; //Player's current shields = UI element
    public string m_SelectedPet;

    private GameObject currPet_;
    private GameController gc_; //Game Controller script for easier access
    private bool newPlayer_;

	void Start () 
    {
        gc_ = Camera.main.GetComponent<GameController>();
        newPlayer_ = gc_.m_FirstTimePlayer;

        if(newPlayer_)
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
            m_PointsText.text = gc_.m_Points.ToString();
            m_ShieldsText.text = gc_.m_Shields.ToString();
        }
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
    }

    void RemoveUI()
    {
        Destroy(m_NewPlayerUI);
    }

    //Button function -- When the player presses the "Done" button after typing in a nickname, this function fires
    //                -- The function will remove the new player UI from the game, turn on the Game UI and start setting up the game itself
    public void GiveNickname()
    {
        
        //gc_.SetUpGame();
        if(!string.IsNullOrEmpty(m_NicknameIF.text) && currPet_ != null)
        {
            currPet_.GetComponent<Pet>().m_Nickname = m_NicknameIF.text;
        }
        else if (string.IsNullOrEmpty(m_NicknameIF.text))
        {
            currPet_.GetComponent<Pet>().m_Nickname = currPet_.GetComponent<Pet>().m_PetName;
        }
        
        Destroy(m_NewPlayerUI);
        m_GameUI.SetActive(true);
    }
}
