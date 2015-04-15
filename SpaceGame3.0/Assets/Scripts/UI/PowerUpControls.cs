using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerUpControls : MonoBehaviour 
{
    public GameObject m_Player;

    public Material m_BlankImage;

    public Image m_ActiveBoost;
 
    public Button m_Boost1;
    public Button m_Boost2;
    public Button m_Boost3;

    public void Start()
    {
        m_Player = Camera.main.GetComponent<SpawnPlayer>().m_Player;
    }

    public void Update()
    {
        SetPowerUpImages();
        ItemsUse(gameObject);
    }


    public void SetPowerUpImages()
    {
        if(m_Player.GetComponent<ShipData>().m_Inventory.Count == 0)
        {
            m_Boost1.GetComponent<Image>().material = m_BlankImage;
            m_Boost2.GetComponent<Image>().material = m_BlankImage;
            m_Boost3.GetComponent<Image>().material = m_BlankImage;
        }

        else
        {
            if (m_Player.GetComponent<ShipData>().m_Inventory.Count > 0 && m_Player.GetComponent<ShipData>().m_Inventory.Count < 2)
            {
                //if (m_Player.GetComponent<ShipData>().m_Inventory[0] != null)
                //{
                    m_Boost1.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[0].GetComponent<MeshRenderer>().material;
                //}
            }

            if(m_Player.GetComponent<ShipData>().m_Inventory.Count > 1 && m_Player.GetComponent<ShipData>().m_Inventory.Count < 3)
            {
                m_Boost2.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[1].GetComponent<MeshRenderer>().material;
            }

            if(m_Player.GetComponent<ShipData>().m_Inventory.Count > 2)
            {
                m_Boost3.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[2].GetComponent<MeshRenderer>().material;
            }
        }
            /*if (m_Player.GetComponent<ShipData>().m_Inventory[1] != null)
            {
                m_Boost2.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[1].GetComponent<MeshRenderer>().material;
            }
            else
            {
                m_Boost2.GetComponent<Image>().material = m_BlankImage;
            }

            if (m_Player.GetComponent<ShipData>().m_Inventory[2] != null)
            {
                m_Boost3.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[2].GetComponent<MeshRenderer>().material;
            }
            else
            {
                m_Boost3.GetComponent<Image>().material = m_BlankImage;
            }
        }*/
        
    }

    public void ItemsUse(GameObject item)
    {
        if (Input.GetKey(KeyCode.V))
        {
            if (m_Boost1.GetComponent<Image>().material != m_BlankImage)
            {
                m_ActiveBoost.GetComponent<Image>().material = m_Boost1.GetComponent<Image>().material;
                m_Boost1.GetComponent<Image>().material = m_BlankImage;
                Camera.main.GetComponent<ShipData>().m_Inventory.RemoveAt(0);
                item.GetComponent<PowerUps>().UseItem(item);
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.B))
        {
            if (m_Boost2.GetComponent<Image>().material != m_BlankImage)
            {
                m_ActiveBoost.GetComponent<Image>().material = m_Boost2.GetComponent<Image>().material;
                m_Boost2.GetComponent<Image>().material = m_BlankImage;
                Camera.main.GetComponent<ShipData>().m_Inventory.RemoveAt(1);
                item.GetComponent<PowerUps>().UseItem(item);
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.N))
        {
            if (m_Boost3.GetComponent<Image>().material != m_BlankImage)
            {
                m_ActiveBoost.GetComponent<Image>().material = m_Boost3.GetComponent<Image>().material;
                m_Boost3.GetComponent<Image>().material = m_BlankImage;
                Camera.main.GetComponent<ShipData>().m_Inventory.RemoveAt(2);
                item.GetComponent<PowerUps>().UseItem(item);
            }
            else
            {
                return;
            }
        }
    }

}
