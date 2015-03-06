﻿using UnityEngine;
using System.Collections;


public abstract class State : MonoBehaviour 
{
    public abstract void OnStateEntered();
    public abstract void OnStateExit();
    public abstract void StateUpdate();
    public abstract void StateGUI();
}

