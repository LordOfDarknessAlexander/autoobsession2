using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Ship : MonoBehaviour 
{
    public Slider m_HealthValue;

    public ShipData m_Data;
    public GameObject m_Explosion;

    public int m_ProjectileMultiplier;

    public abstract void ApplyDamage(GameObject ship, int damage);

    public abstract void FireWeapons(string collisionLayerName);
    
}
