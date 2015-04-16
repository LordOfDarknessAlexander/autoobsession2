﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipData : MonoBehaviour 
{
    public Weapon[] m_Weapons;
    public Weapon.WeaponStateData[] m_WeaponState;
    public Rigidbody m_Rigidbody;
    public List<GameObject> m_Inventory = new List<GameObject>(3);
    //public PowerUpControls m_PowerUpControl;
    public GameObject m_NullItem;//used to set inventory list and to give something to set in the power up UI

    public float m_ForwardAccel;
    public float m_VerticalAccel;

    public int m_HP;
    public int m_CurrShield;
    //public int m_MaxShield;
 
    public bool m_HasShield;

    public float GetTotalThrustAccel()
    {
        float retval = 0.0f;

        retval += m_ForwardAccel;

        return retval;
    }

    public float GetTotalVertAccel()
    {
        float retval = 0.0f;

        retval += m_VerticalAccel;

        return retval;
    }


    public void AddItem(GameObject item)
    {
        if (m_Inventory.Count == m_Inventory.Capacity)
        {
            for (int i = 0; i < m_Inventory.Count; ++i)
            {
                if (m_Inventory[i].gameObject == m_NullItem)
                {
                    item.transform.position = gameObject.transform.position;
                    item.transform.parent = gameObject.transform;
                    m_Inventory.Insert(i, item);
                }
            }
        }
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < m_Inventory.Count; ++i)
        {
            if (m_Inventory[i].gameObject == item)
            {
                m_Inventory[i] = null;
            }
        }
    }

	//Use this for initialization
	void Start () 
    {
        m_Inventory.Capacity = 3;

        for (int i = 0; i < m_Inventory.Capacity; ++i)
        {
            m_Inventory.Add(m_NullItem);
        }
	}
	
	//Update is called once per frame
	void FixedUpdate () 
    {
        for (int i = 0; i < m_WeaponState.Length; ++i)
        {
            m_WeaponState[i].UpdateWeapon();
        }
	}
}
