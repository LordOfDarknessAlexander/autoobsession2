using UnityEngine;
using System.Collections;

public class EnemyData : MonoBehaviour
{
    public GameObject[] m_Enemies;
    private GameObject[] enemyTypes_;

    enum EnemyType
    {
        BOSS,
        MINIBOSS,
        LARGE,
        MEDIUM,
        SMALL
    };
}
