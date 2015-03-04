using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [System.Serializable]
    public class WeaponStateData
    {
        [SerializeField]
        public float m_CooldownTimer;
        [SerializeField]
        public int m_Ammo;

        [SerializeField]
        public Vector2 m_Offset;
        [SerializeField]
        public float m_Rotation;

        public void UpdateWeapon()
        {
            if (m_CooldownTimer > 0.0f)
            {
                m_CooldownTimer -= Time.deltaTime;
            }
        }
    };

    public Transform m_Blaster;
    public GameObject m_Shot;
    public float m_Cooldown;
    public int m_MaxAmmo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(WeaponStateData stateData, GameObject parentShip, string collisionLayerName)
    {
        Instantiate(m_Shot, m_Blaster.position, m_Blaster.rotation);

        stateData.m_CooldownTimer = m_Cooldown;
    }
}