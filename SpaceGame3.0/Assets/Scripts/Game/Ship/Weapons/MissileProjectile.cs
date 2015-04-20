using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileProjectile : Projectile 
{
    private GameObject player_;

    private List<Transform> enemies_;
    private Transform currentTarget_;

    private float distance_;

    public void Start()
    {
        player_ = Camera.main.GetComponent<SpawnPlayer>().m_Player;
        currentTarget_ = null;
        enemies_ = new List<Transform>();
        AddPotentialTargets();
        m_Damage = 20;
        player_.GetComponentInChildren<Weapon>().m_MaxAmmo = 50;

        foreach (Weapon weapon in player_.GetComponent<ShipData>().m_Weapons)
        {
            for (int i = 0; i < player_.GetComponent<ShipData>().m_Weapons.Length; ++i)
            {
                player_.GetComponent<ShipData>().m_WeaponState[i].m_Ammo = player_.GetComponentInChildren<Weapon>().m_MaxAmmo;
            }
        }
    }

    public void Update()
    {
        SetTarget();
        if(this.currentTarget_ == null)
        {
            SetTarget();
        }
        distance_ = Vector3.Distance(currentTarget_.position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget_.position, this.GetComponent<Projectile>().m_ForwardAccel * Time.deltaTime);
    }

    private void AddPotentialTargets()
    {
        GameObject[] enemiesInList_ = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy_ in enemiesInList_)
        {
            AddEnemyToList(enemy_.transform);
        }
    }

    private void AddEnemyToList(Transform enemy)
    {
        enemies_.Add(enemy);
    }

    public void DistanceToTarget()
    {
        enemies_.Sort(delegate(Transform t1, Transform t2)
        {
            return Vector3.Distance(t1.transform.position, transform.position).CompareTo(Vector3.Distance(t2.transform.position, transform.position));
        });
    }

    public void SetTarget()
    {
        if(currentTarget_ == null)
        {
            DistanceToTarget();
            currentTarget_ = enemies_[0];
        }
    }

   /* public void TrackEnemy()
    {
        SetTarget();
        distance_ = Vector3.Distance(currentTarget_.position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget_.position, this.GetComponent<Projectile>().m_ForwardAccel * Time.deltaTime);
    }*/
}
