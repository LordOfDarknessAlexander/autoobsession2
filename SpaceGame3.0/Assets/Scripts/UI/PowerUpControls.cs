using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerUpControls : MonoBehaviour 
{
    public GameObject m_Player;
    public GameObject m_Item1;
    public GameObject m_Item2;
    public GameObject m_Item3;

    public Material m_BlankImage;

    public Image m_ActiveBoost;
 
    public Button m_Boost1;
    public Button m_Boost2;
    public Button m_Boost3;

    public void Start()
    {
        m_Player = Camera.main.GetComponent<SpawnPlayer>().m_Player;
 
        m_Boost1.GetComponent<Image>().material = m_BlankImage;
        m_Boost2.GetComponent<Image>().material = m_BlankImage;
        m_Boost3.GetComponent<Image>().material = m_BlankImage;
    }

    public void Update()
    {
        SetPowerUpImages();
        ItemsUse();
    }


    public void SetPowerUpImages()
    {
        if (m_Player.GetComponent<ShipData>().m_Inventory.Count > 0 && m_Player.GetComponent<ShipData>().m_Inventory.Count < 2)
        {
            m_Boost1.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[0].GetComponent<MeshRenderer>().material;
            m_Item1 = m_Player.GetComponent<ShipData>().m_Inventory[0];
        }

        if(m_Player.GetComponent<ShipData>().m_Inventory.Count > 1 && m_Player.GetComponent<ShipData>().m_Inventory.Count < 3)
        {
            m_Boost2.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[1].GetComponent<MeshRenderer>().material;
            m_Item2 = m_Player.GetComponent<ShipData>().m_Inventory[1];
        }

        if(m_Player.GetComponent<ShipData>().m_Inventory.Count > 2)
        {
            m_Boost3.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[2].GetComponent<MeshRenderer>().material;
            m_Item3 = m_Player.GetComponent<ShipData>().m_Inventory[2];
        }
    }

    public void ItemsUse()
    {
        if (Input.GetKey(KeyCode.B))
        {
            if (m_Boost1.GetComponent<Image>().material != m_BlankImage)
            {
                m_ActiveBoost.GetComponent<Image>().material = m_Boost1.GetComponent<Image>().material;
                m_Boost1.GetComponent<Image>().material = m_BlankImage;
                m_Item1.GetComponent<PowerUps>().UseItem(m_Player);
                m_Player.GetComponent<ShipData>().m_Inventory.RemoveAt(0);
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.N))
        {
            if (m_Boost2.GetComponent<Image>().material != m_BlankImage)
            {
                m_ActiveBoost.GetComponent<Image>().material = m_Boost2.GetComponent<Image>().material;
                m_Boost2.GetComponent<Image>().material = m_BlankImage;
                m_Item2.GetComponent<PowerUps>().UseItem(m_Player);
                m_Player.GetComponent<ShipData>().m_Inventory.RemoveAt(1);
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.M))
        {
            if (m_Boost3.GetComponent<Image>().material != m_BlankImage)
            {
                m_ActiveBoost.GetComponent<Image>().material = m_Boost3.GetComponent<Image>().material;
                m_Boost3.GetComponent<Image>().material = m_BlankImage;
                m_Item3.GetComponent<PowerUps>().UseItem(m_Player);
                m_Player.GetComponent<ShipData>().m_Inventory.RemoveAt(2);
            }
            else
            {
                return;
            }
        }
    }

}
