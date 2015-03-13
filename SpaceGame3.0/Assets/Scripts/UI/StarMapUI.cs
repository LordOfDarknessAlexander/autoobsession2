using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarMapUI : MonoBehaviour
{
    public GameObject m_UpgradePanel; //Upgrade panel UI element
    public Text m_HealthText; //Text UI element for the health cost and upgrade level
    public Text m_ShieldText; //Text UI element for the shield cost and upgrade level
    public Text m_DamageText; //Text UI element for the damage cost and upgrade level
    public Text m_EngineText; //Text UI element for the engine cost and upgrade level

    public Button m_Level1;
    public Button m_Level2;
    public Button m_Level3;
    public Button m_Level4;
    public Button m_Level5;

    public GameController m_Control;
    public LevelData m_Level;

    //--------TEMP CODE----------
    public GameObject m_TestObj; //Test object

    void Update()
    {
        m_HealthText.text = "Cost: " + m_TestObj.GetComponent<PlayerShip>().HealthUpgradeCost.ToString() + "\nCurrent Level: " + m_TestObj.GetComponent<PlayerShip>().HealthLevel;
        m_ShieldText.text = "Cost: " + m_TestObj.GetComponent<PlayerShip>().ShieldUpgradeCost.ToString() + "\nCurrent Level: " + m_TestObj.GetComponent<PlayerShip>().ShieldLevel;
        m_DamageText.text = "Cost: " + m_TestObj.GetComponent<PlayerShip>().DamageUpgradeCost.ToString() + "\nCurrent Level: " + m_TestObj.GetComponent<PlayerShip>().DamageLevel;
        m_EngineText.text = "Cost: " + m_TestObj.GetComponent<PlayerShip>().EngineUpgradeCost.ToString() + "\nCurrent Level: " + m_TestObj.GetComponent<PlayerShip>().EngineLevel;
    }

    public void SetLevel(int level)
    {

    }

    //Button function -- If the user presses the spaceship this function will fire
    //                -- The function opens up the Upgrade menu, where they can then upgrade their ship or upgrade to a higher tier ship entirely
    public void UpgradeMenu()
    {
        m_UpgradePanel.SetActive(true);
    }

    public void CloseMenu()
    {
        m_UpgradePanel.SetActive(false);
    }

    public void OnClick()
    {
        if(m_Level1)
        {
            m_Control.m_Level = 1;
            Application.LoadLevel("Main");
        }

        if (m_Level2)
        {
            m_Control.m_Level = 2;
            Application.LoadLevel("Main");
        }

        if (m_Level3)
        {
            m_Control.m_Level = 3;
            Application.LoadLevel("Main");
        }

        if (m_Level4)
        {
            m_Control.m_Level = 4;
            Application.LoadLevel("Main");
        }

        if (m_Level5)
        {
            m_Control.m_Level = 5;
            Application.LoadLevel("Main");
        }
    }
}