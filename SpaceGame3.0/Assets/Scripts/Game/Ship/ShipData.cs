using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipData : MonoBehaviour 
{
    public Weapon[] m_Weapons;
    public Weapon.WeaponStateData[] m_WeaponState;
    public Rigidbody m_Rigidbody;
    public List<GameObject> m_Inventory;
    public PowerUpControls m_PowerUpControl;

    public float m_ForwardAccel;
    public float m_VerticalAccel;

    public int m_HP;
    public int m_CurrShield;
    public int m_MaxShield;
 
    public bool m_HasShield;

    private int maxItemCapacity_; //amount of power ups ship can hold

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
        if(m_Inventory.Count < maxItemCapacity_)
        {
            item.transform.position = gameObject.transform.position;
            item.transform.parent = gameObject.transform;
            m_Inventory.Add(item);
        }
    }

	//Use this for initialization
	void Start () 
    {
        maxItemCapacity_ = 3;
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
