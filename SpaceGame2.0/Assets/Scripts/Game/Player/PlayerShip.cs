using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShip : Ship 
{
    public int m_Tier = 1; //Tier of the ship for upgrades
    public PlayerController m_PController;
    public Sprite m_ShipType;

    private int upgradeCost_;
    private int shieldUpgradeCounter_ = 1; //Amount of upgrades in the shield by the player
    private int engineUpgradeCounter_ = 1; //Amount of upgrades in the engines by the player
    private int damageUpgradeCounter_ = 1; //Amount of upgrades in the damage by the player
    private int healthUpgradeCounter_ = 1; //Amount of upgrades in the health by the player

    public int ShieldUpgradeCost { get { return (Constants.BASE_UPGRADE_COST * m_Tier) * shieldUpgradeCounter_; } }
    public int EngineUpgradeCost { get { return (Constants.BASE_UPGRADE_COST * m_Tier) * engineUpgradeCounter_; } }
    public int DamageUpgradeCost { get { return (Constants.BASE_UPGRADE_COST * m_Tier) * damageUpgradeCounter_; } }
    public int HealthUpgradeCost { get { return (Constants.BASE_UPGRADE_COST * m_Tier) * healthUpgradeCounter_; } }

    public void UpgradeDamage()
    {
        upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_Tier) * damageUpgradeCounter_;
        if(m_PController.m_Salvage >= upgradeCost_)
        {
            if (damageUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
            {
                damageUpgradeCounter_++;
            }
        }
    }
    //Button function
    public void UpgradeEngine()
    {
        upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_Tier) * engineUpgradeCounter_;
        if (m_PController.m_Salvage >= upgradeCost_)
        {
            if (engineUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
            {
                engineUpgradeCounter_++;
            }
        }
    }
    //Button function
    public void UpgradeHealth()
    {
        upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_Tier) * healthUpgradeCounter_;
        if (m_PController.m_Salvage >= upgradeCost_)
        {
            if (healthUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
            {
                healthUpgradeCounter_++;
                m_Data.m_HP += Constants.DEFAULT_UPGRADE_AMT;
            }
        }
    }
    //Button function
    public void UpgradeShield()
    {
        m_Data.m_HasShield = true;
        upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_Tier) * shieldUpgradeCounter_;
        if (m_PController.m_Salvage >= upgradeCost_)
        {
            if (shieldUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
            {
                shieldUpgradeCounter_++;
                m_Data.m_Shield += Constants.DEFAULT_UPGRADE_AMT;
            }
        }
    }
}