using UnityEngine;
using System.Collections;

public class GameBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GameObject obj = (GameObject)Instantiate(other.gameObject);
            //obj.SetActive(false);
            //Camera.main.GetComponent<EnemySpawn>().enemyPool_.Add(obj);
            Vector3 spawnPosition = new Vector3(Random.Range(-Camera.main.GetComponent<Waves>().m_SpawnArea.x,
                                                                          Camera.main.GetComponent<Waves>().m_SpawnArea.x),
                                                                          Camera.main.GetComponent<Waves>().m_SpawnArea.y,
                                                                          Camera.main.GetComponent<Waves>().m_SpawnArea.z);
            Quaternion spawnRotation = Quaternion.identity;
            //gameObject.SetActive(false);
            obj.transform.position = spawnPosition;
            obj.transform.rotation = spawnRotation;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
