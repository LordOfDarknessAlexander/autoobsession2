using UnityEngine;
using System.Collections;

public class SetSprite : MonoBehaviour 
{
    private GameObject sprite_;

    private int tier_;

    //private Sprite currSprite_;
    //private Sprite newSprite_;

    public void GetSpriteImage(Ship ship)
    {

    }

    public void SetSpriteImage(Ship ship, Sprite sprite)
    {
        tier_ = ship.GetComponent<Ship>().m_Tier;
        ship.GetComponent<SpriteRenderer>().sprite = sprite;
    }

}
