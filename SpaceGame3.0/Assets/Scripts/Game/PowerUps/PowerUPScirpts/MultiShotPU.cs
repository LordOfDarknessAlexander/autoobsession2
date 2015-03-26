using UnityEngine;
using System.Collections;

public class MultiShotPU : PowerUps
{
    //when used set player bolt to fire 3 shots
    public override void Start()
    {
        m_IsStorable = true;
    }
    public override void Update()
    {
        if (this.isActiveAndEnabled)
        {
            Vector3 movement = new Vector3(0, m_DropSpeed, 0);

            GetComponent<Rigidbody>().velocity = transform.up * m_DropSpeed;
        }
    }

    public override void ItemAffect(GameObject player)
    {
        throw new System.NotImplementedException();
    }
    public override void UseItem(GameObject player)
    {
        throw new System.NotImplementedException();
    }
}
