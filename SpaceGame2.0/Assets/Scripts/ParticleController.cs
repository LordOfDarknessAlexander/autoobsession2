using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
    {
	    if(!GetComponent<ParticleSystem>().isPlaying)
        {
            ObjectPool.Instance.PoolObject(gameObject);
        }
	}
}

