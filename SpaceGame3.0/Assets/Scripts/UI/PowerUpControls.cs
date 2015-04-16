using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerUpControls : MonoBehaviour 
{
    public GameObject m_Player;
    private GameObject item1_;
    private GameObject item2_;
    private GameObject item3_;

    public Material m_BlankImage;

    public Image m_ActiveBoost;
 
    public Button m_Boost1;
    public Button m_Boost2;
    public Button m_Boost3;

    public void Start()
    {
        m_Player = Camera.main.GetComponent<SpawnPlayer>().m_Player;
 
        //m_Boost1.GetComponent<Image>().material = m_BlankImage;
        //m_Boost2.GetComponent<Image>().material = m_BlankImage;
        //m_Boost3.GetComponent<Image>().material = m_BlankImage;
    }

    public void Update()
    {
        SetPowerUpImages();
        ItemsUse();
        Debug.Log("Item1 = " + item1_);
        Debug.Log("Item2 = " + item2_);
        Debug.Log("Item3 = " + item3_);
    }


    public void SetPowerUpImages()
    {
        //if (m_Player.GetComponent<ShipData>().m_Inventory.Count > 0 && m_Player.GetComponent<ShipData>().m_Inventory.Count < 2)
        //{
            item1_ = m_Player.GetComponent<ShipData>().m_Inventory[0];
            //if (m_Player.GetComponent<ShipData>().m_Inventory[0] != null)
            //{
                m_Boost1.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[0].GetComponent<MeshRenderer>().sharedMaterial;
            //}
            //else
            //{
                //m_Boost1.GetComponent<Image>().material = m_BlankImage;
            //}
        //}

        //if(m_Player.GetComponent<ShipData>().m_Inventory.Count > 1 && m_Player.GetComponent<ShipData>().m_Inventory.Count < 3)
        //{
            item2_ = m_Player.GetComponent<ShipData>().m_Inventory[1];
            //if(m_Player.GetComponent<ShipData>().m_Inventory[1] != null)
            //{
                m_Boost2.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[1].GetComponent<MeshRenderer>().sharedMaterial;
            //}
            //else
            //{
                //m_Boost2.GetComponent<Image>().material = m_BlankImage;
            //}
        //}

        //if(m_Player.GetComponent<ShipData>().m_Inventory.Count > 2)
        //{
            item3_ = m_Player.GetComponent<ShipData>().m_Inventory[2];
            //if (m_Player.GetComponent<ShipData>().m_Inventory != null)
            //{
                m_Boost3.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[2].GetComponent<MeshRenderer>().sharedMaterial;
            //}
            //else
            //{
                //m_Boost3.GetComponent<Image>().material = m_BlankImage;
            //}
        //}
    }

    public void ItemsUse()
    {
        if (Input.GetKey(KeyCode.B))
        {
            if (m_Boost1.GetComponent<Image>().material != m_BlankImage)
            {
                m_ActiveBoost.GetComponent<Image>().material = m_Boost1.GetComponent<Image>().material;
                m_Player.GetComponent<ShipData>().m_Inventory[0].GetComponent<PowerUps>().UseItem(m_Player);
                m_Player.GetComponent<ShipData>().m_Inventory[0] = m_Player.GetComponent<ShipData>().m_NullItem;
                Debug.Log("Item1 = " + item1_);
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
                m_Player.GetComponent<ShipData>().m_Inventory[1].GetComponent<PowerUps>().UseItem(m_Player);
                m_Player.GetComponent<ShipData>().m_Inventory[1] = m_Player.GetComponent<ShipData>().m_NullItem;
                Debug.Log("Item2 = " + item2_);
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
                m_Player.GetComponent<ShipData>().m_Inventory[2].GetComponent<PowerUps>().UseItem(m_Player);
                m_Player.GetComponent<ShipData>().m_Inventory[2] = m_Player.GetComponent<ShipData>().m_NullItem;
                Debug.Log("Item3 = " + item3_);
            }
            else
            {
                return;
            }
        }
    }

}
