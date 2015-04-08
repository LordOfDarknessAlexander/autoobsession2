using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour 
{
    public PlayerData m_PData;

    public Weapon m_WeaponData;
    public ShipController m_ShipController;
    public PlayerShip m_PlayerShip;
    public Boundary m_PlayerBoundary;

    public float m_MaxVel;
    public float m_FireRate;
    public int m_Salvage;

    private float nextShot_;
    private GameObject player_;

    public void Start()
    {
        nextShot_ = 0.0f;
        m_PlayerShip = Camera.main.GetComponent<SpawnPlayer>().m_Player.GetComponent<PlayerShip>();
        m_ShipController = Camera.main.GetComponent<SpawnPlayer>().m_Player.GetComponent<ShipController>();
        player_ = Camera.main.GetComponent<SpawnPlayer>().m_Player;
    }

    public void Update()
    {
        //to move player around scene
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveShip = new Vector3((moveHorizontal * m_PlayerShip.m_SData.GetTotalVertAccel()), (moveVertical * m_PlayerShip.m_SData.GetTotalThrustAccel()), 0.0f);

        this.GetComponent<Rigidbody>().velocity = moveShip;

        this.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, m_MaxVel);

        //to keep player from leaving play area
        this.GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, m_PlayerBoundary.xMin, m_PlayerBoundary.xMax),
                                         Mathf.Clamp(GetComponent<Rigidbody>().position.y, m_PlayerBoundary.yMin, m_PlayerBoundary.yMax),
                                         0.0f);

        //check for shields
        /*if (m_PlayerShip.m_SData.m_HasShield)
        {
            m_PlayerShip.m_SData.m_Shield = 0;
            m_PlayerShip.m_ShieldData.SetShield(player_);
        }*/


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
