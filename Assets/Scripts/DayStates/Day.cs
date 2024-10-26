using System;
using UnityEngine;

public class Day : MonoBehaviour
{
    // there are 7 days in the game, each day has 3 daystates and are dynamically modified based on players actions
    private DayState currentState;

    private DayState[] dayStates;

    MorningState morningState;
    AfternoonState afternoonState;
    NightState nightState;

    public DayState CurrentState { get => currentState; private set => currentState = value; }
    public MorningState MorningState { get => morningState; } // used for passing events
    public AfternoonState AfternoonState { get => afternoonState; } // used for passing events
    public NightState NightState { get => nightState; } // used for passing events

    public void InitializeDay(int morningp, int afternoonp, int nightp)
    {
        // initialize the day states
        dayStates = new DayState[3];
        dayStates[0] = new MorningState();
        dayStates[0].Init("Morning", morningp);

        morningState = (MorningState)dayStates[0];


        dayStates[1] = new AfternoonState();
        dayStates[1].Init("Afternoon", afternoonp);
        afternoonState = (AfternoonState)dayStates[1];


        dayStates[2] = new NightState();
        dayStates[2].Init("Night", nightp);
        nightState = (NightState)dayStates[2];

        // set the initial state to morning
        CurrentState = dayStates[0];
        CurrentState.OnStateEnter();
    }
   
    public void ChangeState(DayState state)
    {
        CurrentState.OnStateExit();
        CurrentState = state;
        CurrentState.OnStateEnter();
    }
}
