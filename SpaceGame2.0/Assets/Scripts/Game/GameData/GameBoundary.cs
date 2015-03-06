using UnityEngine;
using System.Collections;

public class GameBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GameObject obj = (GameObject)Instantiate(other.gameObject);
            obj.SetActive(false);
            Camera.main.GetComponent<EnemySpawn>().enemyPool_.Add(obj);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
