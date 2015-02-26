using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour 
{
    public const float AUTO_SAVE_TIME = 100.0f; //Max time for the autosave timer

    public const int MAX_PETS = 6; //Maximum amount of pets you can own
    public const int FEED_AMOUNT = 5; //Amount to decrease hunger by
    public const int PLAY_AMOUNT = 5; //Amount to decrease boredom by
    public const int CLEAN_AMOUNT = 5; //Amount to decrease cleanliness by
    public const int MAX_PET_STAT = 100; //Highest any of the pet stats - hunger, boredom, cleanliness - can go
    public const int MIN_PET_STAT = 0; //Lowest any of the pet stats - hunger, boredom, cleanliness - can go
}