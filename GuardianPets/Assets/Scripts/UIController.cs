using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    public GameObject m_GameUI;
    public GameObject m_NewPlayerUI;
    public GameObject m_NicknamePanel; //Panel for nickname prompt
    public GameObject m_FearPanel; //Panel for the fear prompt
    public GameObject m_CurrentPet; //UI Element for the current pet
    public InputField m_NicknameIF; //Input field for the nickname prompt
    public InputField m_FearIF; //Input field for the fear prompt
    public PlayerData m_PlayerData; //Player data

    public Text m_NicknameText;
    public Text m_PointsText; //Player's current points - UI element
    public Text m_ShieldsText; //Player's current shields = UI element
    public Text m_PointsTimerText; //Text element for the Points - UI element
    public string m_SelectedPet;

    private GameObject currPet_;
    
    private GameController gc_; //Game Controller script for easier access
    private bool isNewPlayer_;
    private float pointsTimer_; //Timer until the player receives their next set of points, starts at 300 because the interval is 5 minutes, and there are 300 seconds in 5 minutes
    private string minutes_;
    private string seconds_;

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

        pointsTimer_ = Constants.POINTS_TIMER;
	}
	
	void Update ()
    {
        currPet_ = gc_.ActivePet;
        if (currPet_ != null)
        {
            m_NicknameText.text = currPet_.GetComponent<Pet>().m_Nickname;
            m_PointsText.text = m_PlayerData.m_Points.ToString();
            m_ShieldsText.text = m_PlayerData.m_Shields.ToString();
            UpdateTimer();
        }
	}

    void UpdateTimer()
    {
        pointsTimer_ -= Time.deltaTime;
        minutes_ = Mathf.Floor(pointsTimer_ / 60).ToString("00");
        seconds_ = (pointsTimer_ % 60).ToString("00");
        m_PointsTimerText.text = minutes_ + ":" + seconds_;

        if(pointsTimer_ <= 0.0f)
        {
            gc_.m_PlayerData.m_Points += 10;
            pointsTimer_ = Constants.POINTS_TIMER;
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

    //Button function -- When the player presses the feed button on the UI it will call this function
    //                -- This function will decrease the hunger level of the pet, remove the appropriate points from the player, and award them shields
    public void Feed()
    {
        if (gc_.m_PlayerData.m_Points >= Constants.ACTION_COST)
        {
            currPet_.GetComponent<Pet>().m_Hunger -= Constants.FEED_AMOUNT;
            if (currPet_.GetComponent<Pet>().m_Hunger >= Constants.MAX_PET_STAT)
            {
                currPet_.GetComponent<Pet>().m_Hunger = Constants.MAX_PET_STAT;
            }
            gc_.m_PlayerData.RemovePoints();
        }
    }

    //Button function -- When the player presses the play button on the UI it will call this function
    //                -- This function will decrease the boredom level of the pet, remove the appropriate points from the player, and award them shields
    public void Play()
    {
        if (gc_.m_PlayerData.m_Points >= Constants.ACTION_COST)
        {
            currPet_.GetComponent<Pet>().m_Bored -= Constants.FEED_AMOUNT;
            if (currPet_.GetComponent<Pet>().m_Bored >= Constants.MAX_PET_STAT)
            {
                currPet_.GetComponent<Pet>().m_Bored = Constants.MAX_PET_STAT;
            }
            gc_.m_PlayerData.RemovePoints();
        }
    }

    //Button function -- When the player presses the clean button on the UI it will call this function
    //                -- This function will decrease the cleanliness level of the pet, remove the appropriate points from the player, and award them shields
    public void Clean()
    {
        if (gc_.m_PlayerData.m_Points >= Constants.ACTION_COST)
        {
            currPet_.GetComponent<Pet>().m_Cleanliness -= Constants.FEED_AMOUNT;
            if (currPet_.GetComponent<Pet>().m_Cleanliness >= Constants.MAX_PET_STAT)
            {
                currPet_.GetComponent<Pet>().m_Cleanliness = Constants.MAX_PET_STAT;
            }
            gc_.m_PlayerData.RemovePoints();
        }
    }
}