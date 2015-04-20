using UnityEngine;
using System.Collections;

public class MissilePU : PowerUps
{
    public override void Start()
    {
        m_IsStorable = true;
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
        //change player shot to missile with 50 ammo.
        //player.GetComponent<Weapon>().m_MaxAmmo = 50;
        player.GetComponentInChildren<Weapon>().SetProjectile(player.GetComponentInChildren<Weapon>().m_ProjectilePrefabs[3]);
        //damage = 20 + 25% per player damage level
        //when out of ammo reset to bolt
        Debug.Log("Use a Missle");
    }
    
    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
    
}
