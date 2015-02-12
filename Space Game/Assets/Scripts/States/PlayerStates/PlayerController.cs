using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : State 
{
    public ShipData m_Ship;
    public ShipController m_ShipController;
    public Weapon m_WeaponData;

    public float m_FireRate;
    public int m_Lives = 3; //Number of lives the player has
    public int m_Score = 0; //Player's current score
    public GameObject m_Shot;
    public Transform m_PlayerBlaster;
    public Boundary m_PlayerBoundary;

    private float nextShot_;
    

    public override void OnStateEntered()
    {
        nextShot_ = 0.0f;
    }

    public override void OnStateExit()
    {

    }

    public override void StateUpdate()
    {
        //to move player around scene
        float moveHorizontal = Input.GetAxis("SideToSide");
        float moveVertical = Input.GetAxis("Forward");

        Vector3 moveShip = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rigidbody.velocity = moveShip * m_Ship.GetTotalThrustAccel();

        //to keep player from leaving play area
        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x, m_PlayerBoundary.xMin, m_PlayerBoundary.xMax),
                                         Mathf.Clamp(rigidbody.position.y, m_PlayerBoundary.yMin, m_PlayerBoundary.yMax),
                                         0.0f);

        //to fire weapons
        if (Input.GetButton("Fire"))
        {
            nextShot_ -= Time.deltaTime;

            if(nextShot_ <= 0.0f)
            {
                Instantiate(m_Shot, m_PlayerBlaster.position, m_PlayerBlaster.rotation);
                nextShot_ = m_FireRate;
            }
        }
    }


    public override void StateGUI()
    {

    }
}
