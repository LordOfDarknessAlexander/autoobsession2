using UnityEngine;
using System.Collections;

public class MyPlayerController : MonoBehaviour
{
    public float m_Speed;
    public float m_FireRate;
    public GameObject m_Shot;
    public Transform m_PlayerBlaster;
    public Boundary m_PlayerBoundry;

    private float nextShot_;
    private float speed_;
    private ShipData engines_;
    private EngineData m_Engines;
    private float numEngines_;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("SideToSide");
        float moveVertical = Input.GetAxis("Forward");

        Vector3 moveShip = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rigidbody.velocity = moveShip * m_Speed;

        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x, m_PlayerBoundry.xMin, m_PlayerBoundry.xMax),
                                         Mathf.Clamp(rigidbody.position.y, m_PlayerBoundry.yMin, m_PlayerBoundry.yMax),
                                         0.0f);

        if (Input.GetButton("Fire") && Time.time > nextShot_)
        {
            nextShot_ = Time.time + m_FireRate;
            Instantiate(m_Shot, m_PlayerBlaster.position, m_PlayerBlaster.rotation);
        }
    }
}
