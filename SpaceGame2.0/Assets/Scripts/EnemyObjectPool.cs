using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyObjectPool : MonoBehaviour 
{
    public static EnemyObjectPool m_Current;
    //public GameObject m_PooledObject;
    public GameObject[] m_PooledShips;
    public int m_PooledAmt;

    List<GameObject> PooledObjects;


    void Awake()
    {
        m_Current = this;
    }

    void Start()
    {
        PooledObjects = new List<GameObject>();
        foreach(GameObject shipObj in m_PooledShips)
        {
            for(int i = 0; i < m_PooledAmt; i++)
            {
                GameObject obj = (GameObject)Instantiate(m_PooledShips[i]);
                obj.SetActive(false);
                PooledObjects.Add(obj);
            }
        }

        
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < PooledObjects.Count; i++)
        {
            if(!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        return null;
    }
}
