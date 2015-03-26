using UnityEngine;
using System.Collections;

public class NukePU : PowerUps
{
    // when used destroy all enemies
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
        Camera.main.GetComponent<EnemySpawn>().DestroyAll();
    }
    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}