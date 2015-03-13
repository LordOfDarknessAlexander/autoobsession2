﻿using UnityEngine;
using System.Collections;

public class PlayerShip : Ship 
{
    public PlayerController m_PController;
    public GameController m_GControl;
    public PlayerData m_PData;

    private int upgradeCost_;
    private int shieldUpgradeCounter_ = 1; //Amount of upgrades in the shield by the player
    private int engineUpgradeCounter_ = 1; //Amount of upgrades in the engines by the player
    private int damageUpgradeCounter_ = 1; //Amount of upgrades in the damage by the player
    private int healthUpgradeCounter_ = 1; //Amount of upgrades in the health by the player
    private int tierUpgradeCounter_ = 1; //Level of PlayerShip

    public int ShieldUpgradeCost{ get{ return (Constants.BASE_UPGRADE_COST * m_Tier) * shieldUpgradeCounter_;}}
    public int EngineUpgradeCost{ get{ return (Constants.BASE_UPGRADE_COST * m_Tier) * engineUpgradeCounter_;}}
    public int DamageUpgradeCost{ get{ return (Constants.BASE_UPGRADE_COST * m_Tier) * damageUpgradeCounter_;}}
    public int HealthUpgradeCost{ get{ return (Constants.BASE_UPGRADE_COST * m_Tier) * healthUpgradeCounter_;}}
    public int TierUpgradeCost{ get{ return (Constants.BASE_SHIP_COST * m_Tier) * tierUpgradeCounter_;}}

    public int EngineLevel { get { return engineUpgradeCounter_; } set { engineUpgradeCounter_ = value; } }
    public int ShieldLevel { get { return shieldUpgradeCounter_; } set { shieldUpgradeCounter_ = value; } }
    public int DamageLevel { get { return damageUpgradeCounter_; } set { damageUpgradeCounter_ = value; } }
    public int HealthLevel { get { return healthUpgradeCounter_; } set { healthUpgradeCounter_ = value; } }
    public int Tier { get { return tierUpgradeCounter_; } set { tierUpgradeCounter_ = value; } }

    public void Start()
    {
        m_Tier = 1 * tierUpgradeCounter_;
        m_PController = m_GControl.GetComponent<GameController>().m_Player.GetComponent<PlayerController>();

        shieldUpgradeCounter_ = m_PData.m_ShieldUpgrade;
        healthUpgradeCounter_ = m_PData.m_HealthUpgrade;
        damageUpgradeCounter_ = m_PData.m_DamageUpgrade;
        engineUpgradeCounter_ = m_PData.m_EngineUpgrade;
        tierUpgradeCounter_ = m_PData.m_ShipTier;

    }

    public void ChangeSpirte()
    {
       m_PController.m_PlayerShip.GetComponent<SpriteRenderer>().sprite = m_Sprites[m_Tier];
    }
}
