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
        nextShot_ = 0.0f;
        m_PlayerShip = Camera.main.GetComponent<SpawnPlayer>().m_Player.GetComponent<PlayerShip>();
        m_ShipController = Camera.main.GetComponent<SpawnPlayer>().m_Player.GetComponent<ShipController>();
    }

    public void Update()
    {
        //to move player around scene
        float moveHorizontal = Input.GetAxis("Horizontal");
        /*if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            Debug.Log("Horizontal Has been pressed is true" + moveHorizontal);
        }*/

        float moveVertical = Input.GetAxis("Vertical");
        /*if(moveVertical > 0.1f || moveVertical < -0.1f)
        {
            Debug.Log("Vertical has been pressed  is true" + moveVertical);
        }*/
        

        Vector3 moveShip = new Vector3(moveHorizontal, moveVertical, 0.0f);

        this.GetComponent<Rigidbody>().velocity = moveShip * m_PlayerShip.m_SData.GetTotalThrustAccel();

        //to keep player from leaving play area
        this.GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, m_PlayerBoundary.xMin, m_PlayerBoundary.xMax),
                                         Mathf.Clamp(GetComponent<Rigidbody>().position.y, m_PlayerBoundary.yMin, m_PlayerBoundary.yMax),
                                         0.0f);

        //to fire weapons
        if (Input.GetButton("Fire"))
        {
            nextShot_ -= Time.deltaTime;

            if(nextShot_ <= 0.0f)
            {
                m_ShipController.FireWeapons("PlayerShot");

                nextShot_ = m_FireRate;
            }
        }
    }
}
