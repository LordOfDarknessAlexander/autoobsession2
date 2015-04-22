using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileProjectile : Projectile 
{
    private List<Transform> enemies_;
    private List<Transform> missiles_;
    public  GameObject m_CurrentTarget;

    private float speed_ = 10.0f;

    public void Start()
    {
        m_CurrentTarget = null;
        enemies_ = new List<Transform>();
        missiles_ = new List<Transform>();
        AddPotentialTargets();
        AddOtherMissiles();
        m_Damage = 10;
    }

    public void Update()
    {
        SetTarget();
        if (m_CurrentTarget != null)
        {
            Vector3 dir = transform.position - m_CurrentTarget.transform.position;
            float angle = ((Mathf.Atan2(dir.y, dir.x)) * Mathf.Rad2Deg) + 90.0f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, speed_);

            transform.position = Vector3.MoveTowards(transform.position, m_CurrentTarget.transform.position, this.m_ForwardAccel * Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = transform.up * m_ForwardAccel;
        }
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
        if(enemies_.Count > 0)
        {
            //check for current target, if it is null set a target
            if(m_CurrentTarget == null)
            {
                DistanceToTarget();
                m_CurrentTarget = enemies_[0].gameObject;
                if (missiles_.Count > 1)
                {
                    for (int i = 0; i < missiles_.Count; ++i)
                    {
                        if(missiles_[i].GetComponent<MissileProjectile>().m_CurrentTarget != null)
                        {
                            for (int j = 0; j < enemies_.Count; ++j)
                            {
                                if (m_CurrentTarget.name == missiles_[i].GetComponent<MissileProjectile>().m_CurrentTarget.name)
                                {
                                    m_CurrentTarget = enemies_[j + 1].gameObject;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
           }
        }
        else
        {
            return;
        }
    }

    private void AddOtherMissiles()
    {
        GameObject[] missilesInList_ = GameObject.FindGameObjectsWithTag("PlayerShot");
        foreach (GameObject missile_ in missilesInList_)
        {
            AddMissileToList(missile_.transform);
        }
    }

    private void AddMissileToList(Transform missile)
    {
        missiles_.Add(missile);
    }

}
