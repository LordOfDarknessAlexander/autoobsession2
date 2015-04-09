using UnityEngine;
using System.Collections;

public class ShieldPU : PowerUps
{
    public override void Start()
    {
        m_IsStorable = false;
    }
    public override void Update()
    {
        if (this.isActiveAndEnabled)
        {
            Vector3 movement = new Vector3(0, m_DropSpeed, 0);

            GetComponent<Rigidbody>().velocity = transform.up * m_DropSpeed;
        }
    }

    public override void ItemAffect(GameObject player)
    {
        //if player has shields, set players shields to their max hp
        if(player.GetComponent<ShipData>().m_HasShield)
        {
            //check to see if shield health under its max, if not then do nothing
            if (player.GetComponent<ShipData>().m_CurrShield < player.GetComponent<PlayerShip>().m_MaxShieldHP)
            {
                player.GetComponent<PlayerShip>().m_ShieldData.SetShield(player);
                player.GetComponent<ShipData>().m_CurrShield = m_PData.m_Shield;
            }
            else
            {
                return;
            }
        }
        //if player does not have shields, set HasShield to true at max for player lvl
        else
        {
            player.GetComponent<ShipData>().m_HasShield = true;
            player.GetComponent<ShipData>().m_CurrShield = m_PData.m_Shield;
            player.GetComponent<PlayerShip>().m_ShieldData.SetShield(player);
        }
    }
    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}
