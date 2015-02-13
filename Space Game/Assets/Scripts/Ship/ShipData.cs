using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipData : MonoBehaviour 
{

    public EngineData[] m_Engines;
    public Weapon[] m_Weapons;
    public Weapon.WeaponStateData[] m_WeaponState;
    public Rigidbody m_Rigidbody;
    public List<GameObject> m_Inventory;

    public float m_CargoCapacity; //amount ship can hold in Kg
    public float m_CurrentMass;
    public float m_ShipMass;
    public int m_HP;
    public int m_Shield;
    public int m_Damage;
    public bool m_HasShield;

    public float GetTotalThrustAccel()
    {
        float retval = 0.0f;

        foreach(EngineData engine in m_Engines)
        {
            retval += engine.mForwardAccel;
        }

        return retval;
    }

    public float GetTotalVertAccel()
    {
        float retval = 0.0f;

        foreach (EngineData engine in m_Engines)
        {
            retval += engine.mVerticalAccel;
        }

        return retval;
    }

    public void AddItem(GameObject item)
    {
        float newMass = m_CurrentMass + item.GetComponent<PickupItem>().mMass;
        if (newMass <= m_CargoCapacity)
        {
            item.transform.position = gameObject.transform.position;
            item.transform.parent = gameObject.transform;
            item.renderer.enabled = false;
            item.collider2D.enabled = false;
            m_CurrentMass = newMass;
            m_Rigidbody.mass = m_ShipMass +  m_CurrentMass;
        }
    }

	// Use this for initialization
	void Start () 
    {
        m_Rigidbody.mass = m_ShipMass + m_CurrentMass;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        for (int i = 0; i < m_WeaponState.Length; ++i)
        {
            m_WeaponState[i].UpdateWeapon();
        }
	}
}
