using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public List<GameObject> m_Pets = new List<GameObject>();
    public int m_Points;
    public int m_Shields;

    private int counter_ = 0;

	void Start ()
    {

	}
	
	void Update ()
    {
	
	}

    //This function is called by the button functions from the pets, this removes the points from the player (it's always the same) and increments a counter
    //Once this counter reaches a certain number, it will add shields to the player's account
    public void RemovePoints()
    {
        m_Points -= 20;
        counter_++;
        if(counter_ >= Constants.COUNTER_MAX)
        {
            m_Shields += 10;
            counter_ = 0;
        }
    }
}
