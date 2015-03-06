using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour 
{
    public static ObjectPool m_Current;
    public GameObject m_PooledObject;
    public int m_PooledAmt;

    public List<GameObject> PooledObjects;

    void Start()
    {
        PooledObjects = new List<GameObject>();
        for(int i = 0; i < m_PooledAmt; i++)
        {
            GameObject obj = (GameObject)Instantiate(m_PooledObject);
            obj.SetActive(false);
            PooledObjects.Add(obj);
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
