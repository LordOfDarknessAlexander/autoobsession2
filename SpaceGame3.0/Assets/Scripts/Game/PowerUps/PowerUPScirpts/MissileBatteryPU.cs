using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileBatteryPU : PowerUps
{
    public GameObject m_MissilePrefab;

    public List<Transform> m_Missiles = new List<Transform>();
    public List<Transform> m_LaunchPoints = new List<Transform>();
    
    public float m_LaunchTimer;
    public float m_Launch;

    private Task launchMissiles_;

    public override void Start()
    {
        m_IsStorable = true;
        m_Missiles.Capacity = 10;
    }
    public override void Update()
    {
        if (this.isActiveAndEnabled)
        {
            Vector3 movement = new Vector3(0, m_DropSpeed, 0);

            GetComponent<Rigidbody>().velocity = movement;
        }
    }

    //launch 10 missiles without tracking
    public override void ItemAffect(GameObject player)
    {
        //set missile list to contain 10
        for (int i = 0; i < m_Missiles.Capacity; ++i)
        {
            m_Missiles.Add(m_MissilePrefab.transform);
        }
        launchMissiles_ = new Task(Launch(), true);
        //launch 10 missiles from the 10 launch points
        //set them on a delay by 0.5 seconds, 1(6, -6), 2(5, -5), 3(4, -4), 4(3, -3), 5(2 , -2)
    }

    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }

    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(m_Launch);

        while (m_Missiles.Capacity > 0)
        {
            for(int i = 0; i < m_Missiles.Count; ++i)
            {
                for (int j = 0; j < m_LaunchPoints.Count; ++i)
                {
                    m_Missiles[i] = m_LaunchPoints[j];
                    Instantiate(m_Missiles[i]);
                    m_Missiles.RemoveAt(i);
                }
            }
        }
        yield return new WaitForSeconds(m_LaunchTimer);
    }
}
