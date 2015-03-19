using UnityEngine;
using System.Collections;

public class SetSprite : MonoBehaviour 
{
    public Sprite[] m_SpritesToUse;

    private int tier_;

    private Sprite currSprite_;
    private Sprite newSprite_;

    private int type_;

    public void Awake()
    {
        // load all sprites in Sprites to Load array
        m_SpritesToUse = Resources.LoadAll<Sprite>("Sprites");
    }

    public void GetSpriteImage(Ship ship)
    {
        ship.GetComponent<SpriteRenderer>().sprite = currSprite_;
    }

    public void Sprites(Ship ship)
    {
        tier_ = ship.GetComponent<Ship>().m_Tier;
        type_ = ship.GetComponent<Ship>().m_Level;
        newSprite_ = m_SpritesToUse[tier_ * type_];
    }

    public void SetSpriteImage(Ship ship, Sprite sprite)
    {
        sprite = newSprite_;
        ship.GetComponent<SpriteRenderer>().sprite = sprite;
    }


}
