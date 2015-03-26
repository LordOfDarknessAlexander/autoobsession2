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
            player.GetComponent<ShipData>().m_Shield = m_PData.m_Shield;
        }
        //if player does not have shields, set HasShield to true at max for plyer lvl
        else
        {
            player.GetComponent<ShipData>().m_HasShield = true;
            player.GetComponent<ShipData>().m_Shield = m_PData.m_Shield;
        }
    }
    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}
