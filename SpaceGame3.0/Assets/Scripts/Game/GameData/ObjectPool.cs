using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour 
{
    public static ObjectPool m_Current;
    
    // The object prefabs which the pool can handle.
    public GameObject[] m_ObjectPrefabs;

    // The pooled objects currently available.
    public List<GameObject>[] m_PooledObjects;

    // The amount of objects of each type to buffer.
    public int[] m_AmtToPool;

    public int m_DefaultPoolAmt;

    // The container object that we will keep unused pooled objects so we dont clog up the editor with objects.
    protected GameObject containerObject;


    public void Awake()
    {
        m_Current = this;
    }

    void Start()
    {
        containerObject = new GameObject("ObjectPool");

        //Loop through the object prefabs and make a new list for each one.
        //We do this because the pool can only support prefabs set to it in the editor,
        //so we can assume the lists of pooled objects are in the same order as object prefabs in the array
        m_PooledObjects = new List<GameObject>[m_ObjectPrefabs.Length];

        int i = 0;
        foreach (GameObject objectPrefab in m_ObjectPrefabs)
        {
            m_PooledObjects[i] = new List<GameObject>();

            int bufferAmount;

            if (i < m_AmtToPool.Length)
            {
                bufferAmount = m_AmtToPool[i];
            }
            else
            {
                bufferAmount = m_DefaultPoolAmt;
            }

            for (int j = 0; j < bufferAmount; j++)
            {
                GameObject newObj = Instantiate(objectPrefab) as GameObject;
                newObj.name = objectPrefab.name;
                PoolObject(newObj);
            }
            i++;
        }
    }

    //Gets a new object for the name type provided.  
    //If no object type exists or if onlypooled is true and there is no objects of that type in the pool then null will be returned.

    public GameObject GetObjectForType(string objectType, bool onlyPooled)
    {
        for (int i = 0; i < m_PooledObjects.Length; i++)
        {
            GameObject prefab = m_ObjectPrefabs[i];
            if (prefab.name == objectType)
            {
                if (m_PooledObjects[i].Count > 0)
                {
                    GameObject m_PooledObject = m_PooledObjects[i][0];
                    m_PooledObjects[i].RemoveAt(0);
                    m_PooledObject.transform.parent = null;
                    m_PooledObject.SetActive(true);

                    return m_PooledObject;
                }
                else if (!onlyPooled)
                {
                    return Instantiate(m_ObjectPrefabs[i]) as GameObject;
                }
                break;
            }
        }
        return null;
    }

    // Pools the object specified.  Will not be pooled if there is no prefab of that type.
    public void PoolObject(GameObject obj)
    {
        for (int i = 0; i < m_ObjectPrefabs.Length; i++)
        {
            if (m_ObjectPrefabs[i].name == obj.name)
            {
                obj.SetActive(false);
                obj.transform.parent = containerObject.transform;
                m_PooledObjects[i].Add(obj);
                return;
            }
        }
    }
}
