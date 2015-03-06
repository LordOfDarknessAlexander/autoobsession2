using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour 
{
    public Weapon m_WeaponData;
    public ShipController m_ShipController;
    public PlayerShip m_PlayerShip;
    public Boundary m_PlayerBoundary;

    public float m_FireRate;
    public int m_Salvage;

    private float nextShot_;

    public void Start()
    {
        m_PlayerShip = Camera.main.GetComponent<SpawnPlayer>().m_Player.GetComponent<PlayerShip>();
        nextShot_ = 0.0f;
    }

    public void Update()
    {
        //to move player around scene
        float moveHorizontal = Input.GetAxis("SideToSide");
        float moveVertical = Input.GetAxis("Forward");

        Vector3 moveShip = new Vector3(moveHorizontal, moveVertical, 0.0f);

        GetComponent<Rigidbody>().velocity = moveShip * m_PlayerShip.m_Data.GetTotalThrustAccel();

        //to keep player from leaving play area
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, m_PlayerBoundary.xMin, m_PlayerBoundary.xMax),
                                         Mathf.Clamp(GetComponent<Rigidbody>().position.y, m_PlayerBoundary.yMin, m_PlayerBoundary.yMax),
                                         0.0f);

        //to fire weapons
        if (Input.GetButton("Fire"))
        {
            nextShot_ -= Time.deltaTime;

            if(nextShot_ <= 0.0f)
            {
                m_ShipController.FireWeapons("PlayerShot");

                //Instantiate(m_WeaponData.m_Shot, m_WeaponData.m_Blaster.position, m_WeaponData.m_Blaster.rotation);
                /*m_WeaponData.m_Shot = ObjectPool.m_Current.GetPooledObject();

                m_WeaponData.m_Shot.transform.position = transform.position;
                m_WeaponData.m_Shot.transform.rotation = transform.rotation;
                m_WeaponData.m_Shot.SetActive(true);*/

                nextShot_ = m_FireRate;
            }
        }
    }
}
