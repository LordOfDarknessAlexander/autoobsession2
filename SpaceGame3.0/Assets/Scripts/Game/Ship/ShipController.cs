using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public ShipData m_Data;
    public Ship m_Ship;

    public GameObject m_Explosion;

    private int totalDamage_;

    public void FireWeapons(string collisionLayerName)
    {
        for (int i = 0; i < m_Data.m_WeaponState.Length; ++i)
        {
            if (m_Data.m_WeaponState[i].m_CooldownTimer <= 0.0f)
            {
                m_Data.m_Weapons[i].Fire(m_Data.m_WeaponState[i], gameObject, collisionLayerName);
            }
        }
    }

    public void ApplyDamage(GameObject ship, int damage)
    {
        totalDamage_ = damage * ship.GetComponent<Ship>().m_DamageModifier;

        m_Data.m_HP -= totalDamage_;

        if (m_Data.m_HP <= 0)
        {
            if (ship.tag == "Player")
            {
                StopAllCoroutines();
                Camera.main.GetComponent<GameController>().Respawn();
                ship.SetActive(false);
            }

            if (ship.tag == "Enemy")
            {
                Camera.main.GetComponent<EnemySpawn>().m_NumEnemiesInPool -= 1;
                Camera.main.GetComponent<EnemySpawn>().m_RequiredKills -= 1;
                Camera.main.GetComponent<EnemySpawn>().m_ReqKillText.text = Camera.main.GetComponent<EnemySpawn>().m_RequiredKills.ToString();
                Camera.main.GetComponent<GameController>().m_Score += 100;
                Camera.main.GetComponent<GameController>().m_Salvage += ship.GetComponent<EnemyShip>().m_SalvageVal;
                DropLoot(ship);
                Camera.main.GetComponent<EnemySpawn>().enemyPool_.Remove(ship);
                Destroy(ship);
            }
            Instantiate(m_Explosion, transform.position, transform.rotation);
        }
    }

    private void DropLoot(GameObject ship)
    {
        if(ship.tag == "Enemy")
        {
            this.GetComponent<EnemyShip>().DropLoot(ship);
        }

        if(ship.tag == "Boss")
        {
            this.GetComponent<BossShip>().DropLoot(ship);
            this.GetComponent<BossShip>().BossLootDrop(ship);
        }
    }
}
