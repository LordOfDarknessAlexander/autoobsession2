using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{


    public abstract void OnStateEntered();
    public abstract void OnStateExit();

    public abstract void StateUpdate();
    public abstract void StateGUI();
}
