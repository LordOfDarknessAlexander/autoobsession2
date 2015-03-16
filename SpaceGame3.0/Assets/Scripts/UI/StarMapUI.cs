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
    public Text m_TierText; //Text UI element for the cost of the next tier Ship
    public Text m_Control;//Text element to tell player to upgrade for level they r choosing to play
    public Text m_Salvage;//Amount of Salvage the player has to spend

    public Button m_Health;
    public Button m_Shield;
    public Button m_Damage;
    public Button m_Engine;

    public PlayerData m_PData;
    public GameData m_GData;
    public LevelData m_LData;

    private int upgradeCost_;
    private int shieldUpgradeCounter_; //Amount of upgrades in the shield by the player
    private int engineUpgradeCounter_; //Amount of upgrades in the engines by the player
    private int damageUpgradeCounter_; //Amount of upgrades in the damage by the player
    private int healthUpgradeCounter_; //Amount of upgrades in the health by the player
    private int tierUpgradeCounter_; //Level of PlayerShip

    public int BuyShieldCost
    {
        get
        {
            return (Constants.BASE_UPGRADE_COST * (m_PData.m_ShipTier + 1));
        }
    }

    public int ShieldUpgradeCost
    {
        get
        {
            return (Constants.BASE_UPGRADE_COST * (m_PData.m_ShipTier + 1)) * shieldUpgradeCounter_;
        }
    }
    public int EngineUpgradeCost
    {
        get
        {
            return (Constants.BASE_UPGRADE_COST * (m_PData.m_ShipTier + 1)) * engineUpgradeCounter_;
        }
    }
    public int DamageUpgradeCost
    {
        get
        {
            return (Constants.BASE_UPGRADE_COST * (m_PData.m_ShipTier + 1)) * damageUpgradeCounter_;
        }
    }
    public int HealthUpgradeCost
    {
        get
        {
            return (Constants.BASE_UPGRADE_COST * (m_PData.m_ShipTier + 1)) * healthUpgradeCounter_;
        }
    }
    public int TierUpgradeCost
    {
        get
        {
            return (Constants.BASE_SHIP_COST * (m_PData.m_ShipTier + 1)) * tierUpgradeCounter_;
        }
    }

    public int EngineLevel
    {
        get
        {
            return engineUpgradeCounter_;
        }
        set
        {
            engineUpgradeCounter_ = value;
        }
    }
    public int ShieldLevel
    {
        get
        {
            return shieldUpgradeCounter_;
        }
        set
        {
            shieldUpgradeCounter_ = value;
        }
    }
    public int DamageLevel
    {
        get
        {
            return damageUpgradeCounter_;
        }
        set
        {
            damageUpgradeCounter_ = value;
        }
    }
    public int HealthLevel
    {
        get
        {
            return healthUpgradeCounter_;
        }
        set
        {
            healthUpgradeCounter_ = value;
        }
    }
    public int Tier
    {
        get
        {
            return tierUpgradeCounter_;
        }
        set
        {
            tierUpgradeCounter_ = value;
        }
    }

    void Update()
    {
        shieldUpgradeCounter_ = m_PData.m_ShieldUpgrade;
        healthUpgradeCounter_ = m_PData.m_HealthUpgrade;
        damageUpgradeCounter_ = m_PData.m_DamageUpgrade;
        engineUpgradeCounter_ = m_PData.m_EngineUpgrade;
        tierUpgradeCounter_ = m_PData.m_ShipTier + 1;

        m_Salvage.text = "You have " + m_PData.m_Salvage.ToString() + " Salvage";
        m_HealthText.text = "Cost: " + HealthUpgradeCost.ToString() + "\nCurrent Level: " + HealthLevel;
        if(!m_PData.m_HasShield)
        {
            m_ShieldText.text = "Cost: " + BuyShieldCost.ToString() + "\nCurrent Level: " + ShieldLevel;
        }
        else
        {
            m_ShieldText.text = "Cost: " + ShieldUpgradeCost.ToString() + "\nCurrent Level: " + ShieldLevel;
        }
        m_DamageText.text = "Cost: " + DamageUpgradeCost.ToString() + "\nCurrent Level: " + DamageLevel;
        m_EngineText.text = "Cost: " + EngineUpgradeCost.ToString() + "\nCurrent Level: " + EngineLevel;
        m_TierText.text = "Cost: " + TierUpgradeCost.ToString() + "\nCurrent Level: " + Tier;

    }

    public void SetPlayerData()
    {
        m_PData.m_ShipTier = Tier;
        m_PData.m_HealthUpgrade = HealthLevel;
        m_PData.m_EngineUpgrade = EngineLevel;
        m_PData.m_ShieldUpgrade = ShieldLevel;
        m_PData.m_DamageUpgrade = DamageLevel;
    }

    public void LoadLevel(int level)
    {
        m_LData.SetLevelData(level);
        SetPlayerData();

        //set level requirements
        if((m_PData.m_ShipTier + 1) < level)
        {
            m_Control.text = "Your Ship needs to be Level" + level + " to access this area";
       }
        else
        {
            //Application.LoadLevel("Main");
        }
    }

    //Button function -- If the user presses the spaceship this function will fire
    //                -- The function opens up the Upgrade menu, where they can then upgrade their ship or upgrade to a higher tier ship entirely
    public void UpgradeMenu()
    {
        m_UpgradePanel.SetActive(true);
    }
    //Button function
    public void CloseMenu()
    {
        m_UpgradePanel.SetActive(false);
    }
    //Button function
    public void UpgradeDamage()
    {
        upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipTier) * damageUpgradeCounter_;
        if (m_PData.m_Salvage >= upgradeCost_)
        {
            if (damageUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
            {
                m_PData.m_Salvage -= upgradeCost_;
                damageUpgradeCounter_++;
                m_PData.m_DamageUpgrade = DamageLevel;
            }
        }
    }
    //Button function
    public void UpgradeEngine()
    {
        upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipTier) * engineUpgradeCounter_;
        if (m_PData.m_Salvage >= upgradeCost_)
        {
            if (engineUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
            {
                m_PData.m_Salvage -= upgradeCost_;
                engineUpgradeCounter_++;
                m_PData.m_EngineUpgrade = EngineLevel;
            }
        }
    }
    //Button function
    public void UpgradeHealth()
    {
        upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipTier) * healthUpgradeCounter_;
        if (m_PData.m_Salvage >= upgradeCost_)
        {
            if (healthUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
            {
                m_PData.m_Salvage -= upgradeCost_;
                healthUpgradeCounter_++;
                m_PData.m_HP += Constants.DEFAULT_UPGRADE_AMT;
                m_PData.m_HealthUpgrade = HealthLevel;
            }
        }
    }
    //Button function
    public void UpgradeShield()
    {
        if(!m_PData.m_HasShield)
        {
            upgradeCost_ = Constants.BASE_UPGRADE_COST * m_PData.m_ShipTier + 1;
            if (m_PData.m_Salvage >= upgradeCost_)
            {
                m_PData.m_HasShield = true;
                shieldUpgradeCounter_++;
            }
        }
        else
        {
            upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipTier) * shieldUpgradeCounter_;
            if (m_PData.m_Salvage >= upgradeCost_)
            {
                if (shieldUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
                {
                    m_PData.m_Salvage -= upgradeCost_;
                    shieldUpgradeCounter_++;
                    m_PData.m_Shield += Constants.DEFAULT_UPGRADE_AMT;
                    m_PData.m_ShieldUpgrade = ShieldLevel;
                }
            }
        }
    }
    //Button function
    public void UpgradeShip()
    {
        upgradeCost_ = (Constants.BASE_SHIP_COST * m_PData.m_ShipTier) * tierUpgradeCounter_;
        if (m_PData.m_Salvage >= upgradeCost_)
        {
            if (tierUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
            {
                m_PData.m_Salvage -= upgradeCost_;
                tierUpgradeCounter_++;
                m_PData.m_ShipTier = Tier;
            }
        }
    }
}