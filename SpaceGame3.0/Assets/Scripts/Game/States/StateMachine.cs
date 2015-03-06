using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour 
{
    /*public State mStartState;
    private State currState_;

    public State CurrState
    {
        get
        {
            return currState_;
        }
    }
    

	// Use this for initialization
	void Start () 
    {
        if(mStartState == null)
        {
            Debug.LogError("Each state machine must have a start state set via the inspector view.");
        }
        currState_ = mStartState;
        currState_.OnStateEntered();
  	}
	
	// Update is called once per frame
	void Update () 
    {
        currState_.StateUpdate(); // this could be in fixed update, also we might
                                  // want a fixed update specific function for our state.
	}

    void OnGUI()
    {
        currState_.StateGUI();
    }

    public void ChangeState(State newState)
    {
        currState_.OnStateExit();
        currState_ = newState;
        currState_.OnStateEntered();
    }*/

}
