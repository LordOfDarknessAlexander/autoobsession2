using UnityEngine;
using System.Collections;

public class AmmoPU : PowerUps
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

            GetComponent<Rigidbody>().velocity = movement;
        }
    }

    public override void ItemAffect(GameObject player)
    {
        //set player ammo to max
        foreach(Weapon weapon in player.GetComponent<ShipData>().m_Weapons)
        {
            for(int i = 0; i < player.GetComponent<ShipData>().m_Weapons.Length; ++i)
            {
               player.GetComponent<ShipData>().m_WeaponState[i].m_Ammo = player.GetComponentInChildren<Weapon>().m_MaxAmmo;
            }
        }
    }

    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}

