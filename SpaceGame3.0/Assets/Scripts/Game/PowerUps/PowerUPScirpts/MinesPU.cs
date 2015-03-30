﻿using UnityEngine;
using System.Collections;

public class MinesPU : PowerUps
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

            GetComponent<Rigidbody>().velocity = transform.up * m_DropSpeed;
        }
    }

    //launch 5 mines that spread out and drift until hit by an enemy
    public override void ItemAffect(GameObject player)
    {
        throw new System.NotImplementedException();
    }
    //damage is = 15/each + 25% per player damage level
    public override void UseItem(GameObject player)
    {
        throw new System.NotImplementedException();
    }
}