using UnityEngine;

public class Day : MonoBehaviour
{
    public DayState CurrentState { get; private set; }
    public MorningState MorningState { get; private set; }
    public AfternoonState AfternoonState { get; private set; }
    public NightState NightState { get; private set; }

    public void InitializeDay(int morningPoints, int afternoonPoints, int nightPoints)
    {
        MorningState = new MorningState(morningPoints);
        AfternoonState = new AfternoonState(afternoonPoints);
        NightState = new NightState(nightPoints);

        CurrentState = MorningState;
        CurrentState.OnStateEnter();
    }

    public void ChangeState(DayState newState)
    {
        CurrentState.OnStateExit();
        CurrentState = newState;
        CurrentState.OnStateEnter();
    }
}
