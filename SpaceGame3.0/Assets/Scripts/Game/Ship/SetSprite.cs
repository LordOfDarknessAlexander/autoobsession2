using UnityEngine;
using System.Collections;

public class SetSprite : MonoBehaviour 
{
    private Sprite sprite_;

    private int tier_;

    //private Sprite currSprite_;
    //private Sprite newSprite_;

    public void GetSpriteImage(Ship ship)
    {
        //sprite_ = GetComponent<SpriteRenderer>();
    }

    public enum SpriteType
    {
        TYPE1,
        TYPE2,
        TYPE3,
        TYPE4
    }
    private SpriteType type_ = SpriteType.TYPE1;


    public void SetSpriteImage(Ship ship, Sprite sprite)
    {
        switch(type_)
        {
            case SpriteType.TYPE1:
                break;
            case SpriteType.TYPE2:
                break;
            case SpriteType.TYPE3:
                break;
            case SpriteType.TYPE4:
                break;
        }

        ship.GetComponent<Ship>().m_Tier = tier_;
        ship.GetComponent<SpriteRenderer>().sprite = sprite;
    }


}
