using UnityEngine;
using System.Collections;

public class Paused : State
{

    public Default mDefaultState;

    bool isUnPausable_;

    public override void OnStateEntered()
    {
        isUnPausable_ = false;
    }

    public override void OnStateExit()
    {
    }

    public override void StateUpdate()
    {
        //Debug.Log("Game Paused");

        if(isUnPausable_ && Input.GetAxis("Pause") > 0.0f)
        {
            mStateMachine.ChangeState(mDefaultState);
        }

        if(Input.GetAxis("Pause") <= 0.001f)
        {
            isUnPausable_ = true;
        }

    }

    public override void StateGUI()
    {
        GUI.Label(new Rect(10.0f, 10.0f, 200.0f, 50.0f), "Paused");
    }
}